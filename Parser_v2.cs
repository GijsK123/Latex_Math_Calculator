using System.IO.Pipelines;

public class Parser
{
    Calculator calc = new();

    string[] normalOps = ["+", "-", "*", "/", "^"];
    string[] otherOps = ["log"];
    public float ParseTokens(List<Token> tokens)
    {
        // now, for my final act, a horrendoes chain of for's, if's, and while's
        // finding the largest overhauling open/close brackets to evaluate sub-expressions
        while(tokens.Any(t => t.type == TokenType.OpeningBracket))
        {
            for(int i = 0; i < tokens.Count; i++)
            {
                Token currentToken = tokens[i];
                if(currentToken.type == TokenType.OpeningBracket)
                {
                    for(int j = tokens.Count - 1; j > 0; j--)
                    {
                        Token nextToken = tokens[j];
                        if(nextToken.type == TokenType.ClosingBracket)
                        {
                            float EvaluatedSubExpr = ParseTokens(tokens.GetRange(currentToken.position, nextToken.position));
                        }
                    }
                }
            }
        }


        while(tokens.Any(t => t.type == TokenType.Operation))
        {
            if(tokens.Any(t => t.value == "*" || t.value == "/"))
            {
                for(int k = 0; k < tokens.Count; k++)
                {
                    Token t = tokens[k];
                    if(t.value is "*" or "/")
                    {
                        string op = t.value;
                        string val1 = tokens[k+1].value;
                        string val2 = tokens[k-1].value;

                        float result = EvaluateExpression(op, val1, val2);
                        Token newToken = new Token(TokenType.Number, result.ToString(), k);


                        tokens.RemoveRange(k-1, k+1);
                        tokens.Insert(k-1, newToken);

                    }

                }
            }
            else if()
            else
            {
                // didnt expect yet another for loop did you
                for(int h = 0; h < tokens.Count; h++)
                {
                    Token tAgain = tokens[h];
                    if(tAgain.value is "+" or )
                }
            }
        }
    }


    // behold, one-liner 
    public float EvaluateExpression(string op, string value1, string value2)
    {
        return calc.operations[op](float.Parse(value1), float.Parse(value2));
    }
}