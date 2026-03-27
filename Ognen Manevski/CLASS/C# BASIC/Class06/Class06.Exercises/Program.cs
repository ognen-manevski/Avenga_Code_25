//Task 1
//Create a method called NumberStats that accepts a number. This method should:

//Find out if the number is negative or positive

//Find out if the number is odd or even

//Find out if the number is decimal or integer

//After finding all the stats it should print them like this:

//Stats for number: 25

//Positive
//Integer
//Odd
//The number should be entered in the console by the user.

//Bonus: Validate if the user is entering a number
//Bonus: Ask the user to press Y to try again or X to exit

//==============================================
#region Exercise 1
//==============================================


using Class06.Utilities;

static void Exercise01()
{

    bool exit = false;

    while (!exit)
    {
        double num = Utilities.GetNumInput("Please enter a number to find out its stats:");
        NumberStats(num);

        Console.WriteLine("Enter Y to try again or X to exit");
        string reply = Console.ReadLine().ToLower();

        if (reply == "x")
        {
            exit = true;
        }
    }
}
//Exercise01();


static void NumberStats(double num)
{
    Console.WriteLine(PosOrNeg(num) ? "Positive" : "Negative");
    Console.WriteLine(EvenOdd(num) ? "Even" : "Odd");
    Console.WriteLine(DecOrInt(num) ? "Integer" : "Decimal");
}


static bool PosOrNeg(double num)
{
    return num > 0;
}

static bool EvenOdd(double num)
{
    return num % 2 == 0;
}

static bool DecOrInt(double num)
{
    return num % 1 == 0;
}


#endregion
//==============================================



//==============================================
#region Exercise 1 - From Class
//==============================================

void NumberStats2(double num)
{
    bool isPositive = num > 0;
    bool isDecimal = num % 1 != 0;
    bool isEven = num % 2 == 0;

    Console.WriteLine($"Stats for number {num}");

    Console.WriteLine(string.Format("{0}", isPositive ? "Positive" : "Negative"));
    Console.WriteLine(string.Format("{0}", isDecimal ? "Decimal" : "Integer"));

    if (isDecimal)
    {
        Console.WriteLine("Decimal numbers cant be even or odd.");
        return;
    }
    Console.WriteLine(string.Format("{0}", isEven ? "Even" : "Odd"));
}

//NumberStats2(25);
//NumberStats2(-22.3);
//NumberStats2(-22.4);

bool UserInterface()
{
    Console.WriteLine("Enter a number: ");
    bool isNumber = double.TryParse(Console.ReadLine(), out double num);

    if (!isNumber)
    {
        Console.WriteLine("That was not a number, pls try again.");
        return false;
    }
    NumberStats2(num);

    Console.WriteLine("Press any key to try again or X to exit:");

    if (Console.ReadLine().ToUpper() == "X")
    {
        return true;
    }
    return false;
}

while (!UserInterface()) ;


#endregion
//==============================================