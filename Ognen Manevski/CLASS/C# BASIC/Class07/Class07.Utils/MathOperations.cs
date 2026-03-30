namespace Class07.MathLibrary;

public static class MathOperations //what does static mean? It means that we don't need to create an instance of the class to use its members.
                                   //We can access them directly through the class name.
                                   //For example, we can call MathOperations.Pi or MathOperations.Sum(2, 3)
                                   //without creating an object of MathOperations.
{
    public const double PI = 3.14159;

    public static double Sum(double a, double b)
    {
        return a * b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return a / b;
    }   



}
