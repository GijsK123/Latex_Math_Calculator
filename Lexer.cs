using System;

public class Lexer
{
    

    public List<Token> LexInput(string input)
    {
        List<string> splitInput = input.Where(c => c != '_').Select(c => c.ToString()).ToList();; //splitting every single item
        List<Token> tokens = new List<Token>();

        Console.WriteLine($"split input size = {splitInput.Count}");

        for(int i = 0; i<splitInput.Count; i++)
        {
            string s = splitInput[i];
            if (char.IsDigit(s[0]))
            {
                Token t = new Token(TokenType.Number, s, i);
                tokens.Add(t);
            }
            else if (s[0] == '(')
            {
                Token t = new Token(TokenType.OpeningBracket, s, i);
                tokens.Add(t);

            }
            else if(s[0] == ')')
            {
                Token t = new Token(TokenType.ClosingBracket, s, i);
                tokens.Add(t);
            }
            else
            {
                Token t = new Token(TokenType.Operation, s, i);
                tokens.Add(t);
            }


        }
        return tokens;
    }

    /*
    First, we are going to merge all subsequent numbers together, as well as operators as these
    might be like ['l','o','g'] to turn these into 'log'.
    */
    public List<Token> CleanUpTokens(List<Token> originalTokens)
    {
        List<Token> newList = new List<Token>();

        foreach(Token t in originalTokens)
        {
            Console.WriteLine(t);
        }


        for (int i = 0; i < originalTokens.Count; i++)
        {
            Token current = originalTokens[i];
            string newValue = current.value;

            Console.WriteLine($"New value is: {newValue}");

            // Continue incrementing i while the next token is of the same type
            while (i + 1 < originalTokens.Count && originalTokens[i + 1].type == current.type)
            {
                Console.WriteLine($"The current token is: {originalTokens[i+1]}");
                i++;
                newValue += originalTokens[i].value;
            }


            int newListLe = newList.Count;
            newValue = newValue.Trim();
            newList.Add(new Token(current.type, newValue, newListLength));
        }

        return newList;
    }

    public bool ValidateTokens(List<Token> tokens)
    {
        bool validTokens = true;


        int amountOpenBrackets = tokens.Count(t => t.type == TokenType.OpeningBracket);
        int amountCloseBrackets = tokens.Count(t => t.type == TokenType.ClosingBracket);
        bool sameAmountBrackets = amountOpenBrackets == amountCloseBrackets;



        return validTokens && sameAmountBrackets;
    }
}