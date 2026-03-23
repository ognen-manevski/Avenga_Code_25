//=====================================
#region methods - declaration and usage
//=====================================

// Method that prints a message to the console
// Doesnt return value or it returns void
// Doesnt accept input parameters
static void SaySomething()
{
    Console.WriteLine("Hello, i'm learning C# methods");
    Console.ReadLine();
}

SaySomething();


//Method that accepts an input param of type string
static void SayHelloToSomeone(string person)
{
    Console.WriteLine("Hello there " + person + "! I have to tell you something.");
    Console.ReadLine();
}

SayHelloToSomeone("John");
SayHelloToSomeone("Jane");

//multiple params
static void SendEmail(bool isSenderValid, string msg)
{
    if (isSenderValid)
    {
        Console.WriteLine("The message was sent. Message: " + msg);
    }
    else
    {
        Console.WriteLine("The message was not sent. Message: " + msg);
    }
}

SendEmail(true, "Hi Martin, here is my c# homework!");
SendEmail(false, "Hi Martin, Here is my JS project.");

// method that retuns a value of type 'int'
// and accepts two input parameters of type 'int'
static double Sum(double a, double b)
{
    return a + b;
}

Console.WriteLine(Sum(10, 22));
Console.WriteLine(Sum(100, 321312));

static double Subtract(double a, double b)
{
    return a - b;
}

Console.WriteLine(Subtract(100, 40));
Console.WriteLine(Subtract(2, 10));


static void PrintSomething()
{
    Console.WriteLine("Hello There");
}


#endregion
//=====================================




//=====================================
#region Exercise 1
//=====================================

static double Multiply(double a, double b)
{
    return a * b;
}

static double Divide(double a, double b)
{
    return a / b;
}


//Console.WriteLine("Please enter the operation: [+, -, *, /]");
//string operaton = Console.ReadLine();

//Console.WriteLine("Enter the first number:");
//bool tryA = double.TryParse(Console.ReadLine(), out double a);

//Console.WriteLine("Enter the second number:");
//bool tryB = double.TryParse(Console.ReadLine(), out double b);

//if (!tryA || !tryB)
//{
//    Console.WriteLine("Please enter only number values");
//}
//else
//{

//    if (operaton == "+")
//    {
//        double result = Sum(a, b);
//        Console.WriteLine("The result is: " + result);
//    }

//    if (operaton == "-")
//    {
//        double result = Subtract(a, b);
//        Console.WriteLine("The result is: " + result);
//    }

//    if (operaton == "*")
//    {
//        double result = Multiply(a, b);
//        Console.WriteLine("The result is: " + result);
//    }

//    if (operaton == "/")
//    {
//        if (b == 0)
//        {
//            Console.WriteLine("You cannot divide by zero!");
//        }
//        else
//        {
//            double result = Divide(a, b);
//            Console.WriteLine("The result is: " + result);
//        }
//    }

//    else
//    {
//        Console.WriteLine("Invalid operation");
//    }

//}


//try

static double AskNumber(string msg, bool? isZero)
{
    bool isOk = false;
    double num = 0;

    while (!isOk)
    {

        Console.WriteLine(msg);
        bool tryNumber = double.TryParse(Console.ReadLine(), out double numAnswer);

        if (!tryNumber)
        {
            Console.WriteLine("You must enter a number!");
            continue;
        }

        num = numAnswer;

        if (isZero == true)
        {
            if (num == 0)
            {
                Console.WriteLine("You cannot enter zero!");
                continue;
            }
        }

        isOk = true;
    }

    return num;
}

static string AskOperation(string msg)
{
    Console.WriteLine(msg);
    string operation = Console.ReadLine();

    while (operation != "+" && operation != "-" && operation != "*" && operation != "/")
    {

        Console.WriteLine("Invalid operation! Please enter one of the following: +, -, *, /");
        operation = Console.ReadLine();

    }
    return operation;
}


static void Calculate(string operation, double a, double b)
{
    double result = 0;
    switch (operation)
    {
        case "+": result = Sum(a, b); break;
        case "-": result = Subtract(a, b); break;
        case "*": result = Multiply(a, b); break;
        case "/": result = Divide(a, b); break;
        default: break;
    }
    Console.WriteLine("The result is: " + result);
}

Calculate(
    AskOperation("Please enter the operation: [+, -, *, /]"),
    AskNumber("Enter the first number:", null),
    AskNumber("Enter the second number:", true)
    );





#endregion
//=====================================