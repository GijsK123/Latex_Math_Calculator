using System.IO.Pipelines;

public class Calculator
{

    // perform addition between floating point numbers
    public static float Add(float a, float b)
    {
        return a+b;
    }

    public static float Subt(float a, float b)
    {
        return a-b;
    }

    public static float Div(float a, float b)
    {
        return a/b;
    }

    public static float Mult(float a, float b)
    {
        return a*b;
    }

    // takes the logarithm of the 'val' with base value 'logBase'
    double Log(float val, float logBase)
    {
        return Math.Log(val, logBase);   
    } 


}