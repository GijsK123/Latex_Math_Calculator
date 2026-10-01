
class Program
{

    static void Main(string[] args)
    {
        Lexer lexer = new Lexer();
        while (true)
        {
            Console.WriteLine("Insert a mathematical expression");
            string input = Console.ReadLine();


            List<Token> tokens = lexer.LexInput(input);
            List<Token> cleanedTokens = lexer.CleanUpTokens(tokens);

            bool tokensValid = lexer.ValidateTokens(cleanedTokens);
            if (!tokensValid)
            {
                Console.WriteLine("The given expression was not valid, try again");
                continue;
            }


            /*
            string[] parts = input.Split(' ');
            // It is a latex inline math expression
            if(parts[0] == "$")
            {
                
            }
            else // assuming normal mathematical expression
            {
                string result = MathParser.ParseInput(input);
                Console.WriteLine($"Equation evaluates to: {result}");
            }*/
        }
    }
}