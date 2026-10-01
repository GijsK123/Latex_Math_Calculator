public enum TokenType
{
    Operation,
    Number,
    OpeningBracket,
    ClosingBracket

}

public record Token(
    TokenType type,
    string value,
    int position

);