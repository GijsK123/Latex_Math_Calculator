// A future LaTeX lexer can return the same tokens for the parser to consume.
public interface ILexer
{
    List<Token> LexInput(string input);
}
