using System.IO.Pipelines;

class Calculator
{
    

    // perform addition between floating point numbers
    float Add(float a, float b)
    {
        return a+b;
    }

    float Subt(float a, float b)
    {
        return a-b;
    }

    float Div(float a, float b)
    {
        return a/b;
    }

    float Mult(float a, float b)
    {
        return a*b;
    }

    // takes the logarithm of the 'val' with base value 'logBase'
   float Log(float val, float logBase)
    {
        return Math.Log(val, logBase);   
    } 


}