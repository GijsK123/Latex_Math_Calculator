using System.Linq;


// Class describing a latex formula
public class MathParser
{
    
    static string[] mathematicalOperators = ["+","-","*","/"];

    public static List<(string,float,float)> ParseInput(string[] args)
    {
        
        var expressionList = new List<(string,float,float)>();

        // start at second-to-last item as the last item will never be an operator
        for(int i = args.Length-2; i>=0; i--)
        {
            string currentItem = args[i];

            if (mathematicalOperators.Contains(currentItem))
            {
                float rhs = float.Parse(args[i+1]);
                float lhs = float.Parse(args[i-1]);

                expressionList.Add((currentItem, rhs, lhs));       
            }
        }

        return expressionList;
    }
}


