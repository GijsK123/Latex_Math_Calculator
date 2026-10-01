using System.Linq;


// Class describing a latex formula
public class MathParser
{
    
    static string[] mathematicalOperators = ["+","-","*","/", "^"];
    static string[] specialOperators = ["log", "sqrt"];

    public static string ParseInput(string input)
    {
        int counter = 0;
        while(input.Contains(' ') && counter < 1)
        {
            Console.WriteLine("Restarting ENTIRE loop");
            counter++;
            string[] args = input.Split([' ','_']);

            // start at second-to-last item as the last item will never be an operator
            for(int i = args.Length-1; i>=0; i--)
            {
                string currentItem = args[i];
                Console.WriteLine($"CurrentItem is {currentItem}");

                
                string currentExpression;

                // Checking what operator we are currently working with
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
                Console.WriteLine($"Current expression is: {currentExpression}");

                // Working out brackets!!
                if (input.Contains(')')) // find the whole expression as a sub-expression, evaluate it, continue
                {
                    Console.WriteLine($"Input contains a bracket, current item: {currentItem}");
                    if (currentItem == ")")
                    {
                        Console.WriteLine("Found opening bracket");
                        // find the closing bracket
                        for(int j = i - 1; j >= 0; j--)
                        {
                            int diff = Math.Abs(j-i);
                            if (args[j] == "(") // if diff smaller than 1, there is no value in the brackets
                            {
                                Console.WriteLine("Found closing bracket");
                                string subString = string.Join(" ", args[(j+1)..i]);
                                if(diff <= 1)
                                {
                                    input = input.Replace("( )", "");
                                    break;
                                } 
                                else
                                {
                                    Console.WriteLine($"Now parsing substring: {subString}");
                                    string evaluatedSubString = ParseInput(subString);
                                    input = input.Replace("( " + subString + " )", evaluatedSubString);
                                    break;
                                }
                                
                            }
                    
                        }
                    }
   
                }
                else if (input.Contains("log") || input.Contains("^"))
                {
                    if(currentItem == "log")
                    {
                        float currentResult = EvaluateLogarithm(args, i);
                        input = input.Replace(currentExpression, currentResult.ToString());
                        break;
                    }
                    else if(currentItem == "^")
                    {
                        float currentResult = EvaluateExpression(args, i);

                        input = input.Replace(currentExpression, currentResult.ToString());
                        break;
                    }

                }
                else if (input.Contains('*') || input.Contains('/'))
                {
                    if(currentItem is "*" or "/")
                    {
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
            
            case "^":
                result = Calculator.Pow(item1, item2);
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


