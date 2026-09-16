
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
                    string it1 = item.Item1;
                    float it2 = item.Item2;
                    float it3 = item.Item3;

                    float result = 0f;
                    switch (it1)
                    {
                        case "+":
                            result = Calculator.Add(it2, it3);
                            break;
                        
                        case "-":
                            result = Calculator.Subt(it2, it3);
                            break;
                        default:
                            break;

                        
                    }
                    Console.WriteLine(result);

                }
            }
        }
    }
}