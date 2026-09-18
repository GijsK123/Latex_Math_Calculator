
class Program
{

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Insert a mathematical expression");
            string input = Console.ReadLine();

            string[] parts = input.Split(' ');


            // It is a latex inline math expression
            if(parts[0] == "$")
            {
                
            }
            else // assuming normal mathematical expression
            {
                string result = MathParser.ParseInput(input);
                Console.WriteLine($"Equation evaluates to: {result}");
            }
        }
    }
}