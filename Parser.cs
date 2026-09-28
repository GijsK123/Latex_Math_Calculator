using System.Linq;


// Class describing a latex formula
public class MathParser
{
    
    static string[] mathematicalOperators = ["+","-","*","/"];
    static string[] specialOperators = ["log"];

    public static string ParseInput(string input)
    {
        
        while(input.Contains(' '))
        {
            string[] args = input.Split([' ','_']);

            // start at second-to-last item as the last item will never be an operator
            for(int i = args.Length-1; i>=0; i--)
            {
                string currentItem = args[i];
                Console.WriteLine($"CurrentItem is {currentItem}");

                
                string currentExpression;
                if (mathematicalOperators.Contains(currentItem))
                {
                    currentExpression = args[i-1] + " " + currentItem + " " + args[i+1];
                }
                else if (specialOperators.Contains(currentItem))
                {
                    currentExpression = args[i] + "_" + args[i+1] + " " + args[i+2];
                } 
                else
                {
                    currentExpression = currentItem;
                }   


                // Working out brackets!!
                if (input.Contains(')')) // find the whole expression as a sub-expression, evaluate it, continue
                {
                    if (currentItem == ")")
                    {
                        // find the closing bracket
                        for(int j = i - 1; j >= 0; j--)
                        {
                            int diff = Math.Abs(j-i);
                            if (args[j] == "(") // if diff smaller than 1, there is no value in the brackets
                            {
                                string subString = string.Join(" ", args[(j+1)..i]);
                                if(diff <= 1)
                                {
                                    input = input.Replace("( )", "");
                                    break;
                                } 
                                else
                                {
                                    string evaluatedSubString = ParseInput(subString);
                                    input = input.Replace("( " + subString + " )", evaluatedSubString);
                                    break;
                                }
                                
                            }
                    
                        }
                    }
   
                }
                else if (input.Contains("log"))
                {
                    if(currentItem == "log")
                    {
                        Console.WriteLine("Currently evaluating a logarithm");
                        float currentResult = EvaluateLogarithm(args, i);
                        input = input.Replace(currentExpression, currentResult.ToString());
                        break;
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
                else
                {
                    Console.WriteLine("There was no operator found, something is wrong I think");
                    return "";
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

    public static float EvaluateLogarithm(string[] input, int i)
    {
        int logBase = Int32.Parse(input[i+1]);
        float value = float.Parse(input[i+2]);

        return CalculateExpression("log", value, logBase);
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

            case "log":
                result = Calculator.Log(item1, item2);
                break;

            default:
                break;

                
        }
        
        return result;
    }


    public static void WorkOutBrackets(string[] args, string currentItem, int currentLoc)
    {
        for(int i = currentLoc; i<args.Count(); i++)
        {
            if (args[i] == "(") //start search for closing bracket
            {
                
            }
        }   
    }

}


