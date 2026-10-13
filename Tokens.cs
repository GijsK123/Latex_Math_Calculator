public enum TokenType
{
    Operation,
    Number,
    OpeningBracket,
    ClosingBracket,
    Identifier,
    Comma,
    Underscore
}

// position is the zero-based character offset in the original input, not a token index.
public record Token(
    TokenType type,
    string value,
    int position
);
