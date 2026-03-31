using Class07.MathLibrary;

double num1 = 10.15;
double num2 = 123.43;
double num3 = 1500;
double num4 = 1890;

Console.WriteLine(@$"
{MathOperations.Sum(num1, num2)}
{MathOperations.Divide(num3, num4)}
{MathOperations.Multiply(num2, num4)}
{MathOperations.Divide(num1, num3)}
");


//Console.WriteLine(MathOperations.Divide(num2, 0));