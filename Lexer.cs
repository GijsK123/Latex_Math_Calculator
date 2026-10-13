public sealed class Lexer : ILexer
{
    // Read each token directly from the source so whitespace never joins separate values.
    public List<Token> LexInput(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        List<Token> tokens = new();
        int position = 0;

        while (position < input.Length)
        {
            char current = input[position];

            if (char.IsWhiteSpace(current))
            {
                position++;
                continue;
            }

            int start = position;
            TokenType type;

            if (char.IsAsciiDigit(current) || current == '.')
            {
                ReadNumber(input, ref position);
                type = TokenType.Number;
            }
            else if (char.IsAsciiLetter(current))
            {
                // Function names and variables share a token type; the parser decides their meaning.
                position++;
                while (position < input.Length && char.IsAsciiLetterOrDigit(input[position]))
                {
                    position++;
                }

                type = TokenType.Identifier;
            }
            else
            {
                type = current switch
                {
                    '+' or '-' or '*' or '/' or '^' => TokenType.Operation,
                    '(' => TokenType.OpeningBracket,
                    ')' => TokenType.ClosingBracket,
                    ',' => TokenType.Comma,
                    '_' => TokenType.Underscore,
                    _ => throw new LexerException($"Unexpected character '{current}'.", position)
                };
                position++;
            }

            tokens.Add(new Token(type, input[start..position], start));
        }

        return tokens;
    }

    // This checks only for nonempty input and correctly nested parentheses.
    // Operand order, function arguments and other grammar rules belong in the parser.
    public bool ValidateTokens(List<Token> tokens)
    {
        ArgumentNullException.ThrowIfNull(tokens);

        if (tokens.Count == 0)
        {
            return false;
        }

        int depth = 0;
        foreach (Token token in tokens)
        {
            if (token.type == TokenType.OpeningBracket)
            {
                depth++;
            }
            else if (token.type == TokenType.ClosingBracket)
            {
                depth--;
                if (depth < 0)
                {
                    return false;
                }
            }
        }

        return depth == 0;
    }

    // A number has digits, an optional decimal point and an optional e/E exponent.
    // Leading signs stay separate operators; signs inside an exponent belong to the number.
    private static void ReadNumber(string input, ref int position)
    {
        int start = position;
        ReadDigits(input, ref position);
        bool hasDigits = position > start;

        if (position < input.Length && input[position] == '.')
        {
            position++;
            int fractionStart = position;
            ReadDigits(input, ref position);
            hasDigits |= position > fractionStart;
        }

        if (!hasDigits)
        {
            throw new LexerException("A number must contain at least one digit.", start);
        }

        if (position < input.Length && input[position] is 'e' or 'E')
        {
            int exponentStart = position;
            position++;
            if (position < input.Length && input[position] is '+' or '-')
            {
                position++;
            }

            int digitsStart = position;
            ReadDigits(input, ref position);
            if (position == digitsStart)
            {
                throw new LexerException("An exponent must contain at least one digit.", exponentStart);
            }
        }

        if (position < input.Length && input[position] is '.' or 'e' or 'E')
        {
            throw new LexerException("Unexpected character in a number.", position);
        }
    }

    private static void ReadDigits(string input, ref int position)
    {
        while (position < input.Length && char.IsAsciiDigit(input[position]))
        {
            position++;
        }
    }
}
