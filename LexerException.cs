public sealed class LexerException : FormatException
{
    public int Position { get; }

    public LexerException(string message, int position)
        : base($"{message} At character {position + 1}.")
    {
        Position = position;
    }
}
