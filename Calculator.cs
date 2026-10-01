using System.IO.Pipelines;

public class Calculator
{

    // perform addition between floating point numbers
    public float Add(float a, float b)
    {
        return a+b;
    }

    public float Subt(float a, float b)
    {
        return a-b;
    }

    public float Div(float a, float b)
    {
        return a/b;
    }

    public float Mult(float a, float b)
    {
        return a*b;
    }

    // takes the logarithm of the 'val' with base value 'logBase'
    public float Log(float logBase, float val)
    {
        return (float)Math.Log(val, logBase);   
    } 

    public float Pow(float val, float power)
    {
        return (float)Math.Pow(val, power);
    }



    public Dictionary<string, Func<float, float, float>> operations;

    public Calculator()
    {
        operations = new()
        {
            ["+"] = Add,
            ["-"] = Subt,
            ["*"] = Mult,
            ["/"] = Div,
            ["log"] = Log,
            ["^"] = Pow
        };
    }


}