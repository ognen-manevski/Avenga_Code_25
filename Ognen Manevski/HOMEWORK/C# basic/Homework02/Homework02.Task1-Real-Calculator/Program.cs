//Task 1

//Create new console application called“RealCalculator”
//that takes two numbers from the input and asks what operation
//would the user want to be done ( +, - , * , / ).
//Then it returns the result.

//    Test Data:
//        Enter the First number: 10
//        Enter the Second number: 15
//        Enter the Operation: +
//    Expected Output:
//The result is: 25

using Homework02.Utilities;

Console.WriteLine("============== Task 1: Real Calculator ==================");

double n1 = Utilities.GetNumInput("Enter the first number:");
double n2 = Utilities.GetNumInput("Enter the second number:");

//helper
static string VerifyOperationInput()
{
    bool isValid = false;

    string op = "";

    while (!isValid)
    {
        Console.WriteLine("Enter an operation (+, -, *, /):");
        op = Console.ReadLine();

        if (op != "+" && op != "-" && op != "*" && op != "/")
        {
            Utilities.PrintError("Invalid operation. Please enter one of the following: +, -, *, /");
        }
        isValid = true;
    }
    return op;
}

string op = VerifyOperationInput();

double res = 0;

//helper
static void PrintResult(double n1, string op, double n2, double res)
{
    Utilities.HighlightColor(n1.ToString());
    Console.Write(" " + op + " ");
    Utilities.HighlightColor(n2.ToString());
    Console.Write(" = ");
    Utilities.HighlightColor(res.ToString());
    Console.Write("\n");
}


switch (op)
{
    case "+":
        res = n1 + n2;
        PrintResult(n1, op, n2, res);
        break;
    case "-":
        res = n1 - n2;
        PrintResult(n1, op, n2, res);
        break;
    case "*":
        res = n1 * n2;
        PrintResult(n1, op, n2, res);
        break;
    case "/":
        while (n2 == 0)
        {
            Utilities.PrintError("Cannot divide by zero. Please enter a non-zero second number.");
            n2 = Utilities.GetNumInput("Enter the second number (non-zero):");
        }
        res = n1 / n2;
        PrintResult(n1, op, n2, res);
        break;
    default: break;
}
