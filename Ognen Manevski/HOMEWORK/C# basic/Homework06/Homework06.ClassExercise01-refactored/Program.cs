using Homework06.Utilities;

//==============================================
#region Description
//==============================================

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

#endregion
//==============================================


void Exercise01()
{
    bool exit = false;

    while (!exit)
    {
        double num = Utilities.GetNumInput("Please enter a number to find out its stats:");
        NumberStats(num);

        Console.WriteLine("Enter Y to try again");
        string reply = Console.ReadLine().ToLower();

        if (reply == "y") continue;
        exit = true;
    }
}
Exercise01();

void NumberStats(double num)
{
    Console.WriteLine(DecOrInt(num) ? "Integer" : "Decimal");
    Console.WriteLine(PosOrNeg(num) ? "Positive" : "Negative");
    if (!DecOrInt(num))
    {
        Console.WriteLine("Decimal numbers cant be even or odd.");
        return;
    }
    Console.WriteLine(EvenOdd(num) ? "Even" : "Odd");
}

bool PosOrNeg(double num)
{
    return num >= 0; //considering 0 as positive
}

bool EvenOdd(double num)
{
    return num % 2 == 0;
}

bool DecOrInt(double num)
{
    return num % 1 == 0;
}