using System.Linq;


// Class describing a latex formula
public class MathParser
{
    
    static string[] mathematicalOperators = ["+","-","*","/"];

    public static string ParseInput(string input)
    {
        
        while(input.Contains(' '))
        {
            string[] args = input.Split(' ');

            // start at second-to-last item as the last item will never be an operator
            for(int i = args.Length-1; i>0; i--)
            {
                string currentItem = args[i];
                string currentExpression;
                if (mathematicalOperators.Contains(currentItem))
                {
                    
                    currentExpression = args[i-1] + " " + currentItem + " " + args[i+1];
                } else
                {
                    currentExpression = currentItem;
                }   
                Console.WriteLine("Entering loop");

                if (input.Contains(')')) // find the whole expression as a sub-expression, evaluate it, continue
                {
                    Console.WriteLine($"Loop contained a bracket, current item is: {currentItem}");
                    if (currentItem == ")")
                    {
                        Console.WriteLine("There are brackets, looking for the next bracket");
                        // find the closing bracket
                        for(int j = i; j >= 0; j--)
                        {
                            if (args[j] == "(")
                            {
                                Console.WriteLine("Found closing bracket");
                                string subString = string.Join(" ", args[(j+1)..i]);
                                Console.WriteLine($"The substring is{subString}");
                                string evaluatedSubString = ParseInput(subString);

                                Console.WriteLine($"The substring evaluated to: {evaluatedSubString}");


                                Console.WriteLine($"This is the input before replace: {input}");
                                input = input.Replace("( " + subString + " )", evaluatedSubString);
                                Console.WriteLine($"The current input is then: {input}");
                                break;
                            }
                        }
                    }
   
                }
                else if (input.Contains('*') || input.Contains('/'))
                {
                    if(currentItem is "*" or "/")
                    {
                        Console.WriteLine($"Current item is:{currentItem}");
                        float currentResult = EvaluateExpression(args, i);
                        input = input.Replace(currentExpression, currentResult.ToString());
                        break;
                    }
                } else if (currentItem is "+" or "-"){ // then evaluation the rest
                    float currentResult = EvaluateExpression(args, i);
                    input = input.Replace(currentExpression, currentResult.ToString());
                    break;
                }
            }
        }
        return input;
    }

    // calculate multiplication/division and return the result
    public static float EvaluateExpression(string[] input, int i)
    {   
        // setup expression
        Console.WriteLine($"Input size is still:{input.Length} and i is {i}");

        Console.WriteLine($"Current part: {input[i-1]} {input[i]} {input[i+1]}");
        string currentOp = input[i];
        float rhs = float.Parse(input[i+1]);
        float lhs = float.Parse(input[i-1]);

        float intermediary = CalculateExpression(currentOp, lhs, rhs);
        return intermediary;
    }

    // Function that makes actual calculations on computed input
    public static float CalculateExpression(string op, float item1, float item2)
    {


        float result = 0f;
        switch (op)
        {
            case "+":
                result = Calculator.Add(item1, item2);
                break;
            
            case "-":
                result = Calculator.Subt(item1, item2);
                break;

            case "*":
                result = Calculator.Mult(item1, item2);
                break;

            case "/":
                result = Calculator.Div(item1, item2);
                break;

            default:
                break;

                
        }
        
        return result;
    }
}


