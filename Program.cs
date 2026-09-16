
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
                List<(string,float,float)> parsedInput = MathParser.ParseInput(parts);

                foreach(var item in parsedInput)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}