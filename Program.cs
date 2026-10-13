
class Program
{
    static void Main(string[] args)
    {
        Lexer lexer = new();
        Console.WriteLine("Enter a mathematical expression, or 'exit' to quit.");

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();
            if (input is null || input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            try
            {
                List<Token> tokens = lexer.LexInput(input);
                if (!lexer.ValidateTokens(tokens))
                {
                    Console.WriteLine("Enter a nonempty expression with correctly nested parentheses.");
                    continue;
                }

                // Show the lexer output while the parser is still being developed.
                foreach (Token token in tokens)
                {
                    Console.WriteLine($"{token.type}: '{token.value}' at position {token.position}");
                }
            }
            catch (LexerException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
