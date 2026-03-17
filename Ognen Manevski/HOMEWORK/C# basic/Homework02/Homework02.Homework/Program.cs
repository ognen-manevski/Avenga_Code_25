//=====================================================
#region Helper Methods:
//=====================================================

// get and validate user numeric input
//short? means the method can accept a short value or null (if no min/max is provided)
static short GetNumInput(string promptText, short? min = null, short? max = null)
{
    while (true) // loop until return
    {
        Console.WriteLine(promptText);
        bool isValid = short.TryParse(Console.ReadLine(), out short result);

        if (!isValid)
        {
            PrintError("That isn't a valid number. Please try again.");
            continue; //restart loop
        }

        // if minmax values are provided:
        if (
            (min != null && result < min) ||
            (max != null && result > max)
            )
        {
            PrintError($"Please enter a number between {min} and {max}");
            continue;
        }

        return result;
    }
}

//change error color to red
static void PrintError(string err)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(err);
    Console.ResetColor();
}

//change highlight color to cyan
static void HighlightColor(string txt)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(txt);
    Console.ResetColor();
}


#endregion
//=====================================================


//=====================================================
#region EXERCISE 4
//=====================================================

//EXERCISE 4
//On one tree there are 12 branches with n apples on them.
//One basket can hold m apples.
//n = 8
//m = 5
//If a user enters the number of trees, calculate how many baskets are needed to collect all apples.

static void Exercise4()
{
    Console.WriteLine("\n=== EXERCISE 4: Apple Basket Calculator ===");

    short applesOnBranch = 8;
    short basketSize = 5;
    short numberOfBranches = 12;

    short numOfTrees = GetNumInput("How many trees do you have?"); //helper method

    double applesTotal = numOfTrees * numberOfBranches * applesOnBranch;
    double basketsNeeded = Math.Ceiling(applesTotal / basketSize);

    Console.Write("You will need ");
    HighlightColor(basketsNeeded.ToString());
    Console.WriteLine(" baskets");
}

#endregion
//=====================================================


//=====================================================
#region EXERCISE 5
//=====================================================

//EXERCISE 5
//Create two variables and initialize them
//Determine which number is larger
//Determine whether the larger number is even or odd

//Output example:
//The larger number from the two is X
//And the number is even/odd


static void Exercise5()
{
    Console.WriteLine("\n=== EXERCISE 5: Compare Two Numbers ===");

    short num1 = GetNumInput("Enter the first number:");
    short num2 = GetNumInput("Enter the second number:");

    short larger = num1 > num2 ? num1 : num2;
    string evenOrOdd = larger % 2 == 0 ? "even" : "odd";

    Console.Write("The larger number from the two is ");
    HighlightColor(larger.ToString());
    Console.Write("\nAnd the number is ");
    HighlightColor(evenOrOdd);
    Console.WriteLine(".");
}

#endregion
//=====================================================


//=====================================================
#region EXERCISE 6
//=====================================================

//EXERCISE 6
//Ask the user to enter a number from 1 to 3:

//1 → “You got a new car!”
//2 → “You got a new plane!”
//3 → “You got a new bike!”
//Any other input → error message


static void Exercise6()
{
    Console.WriteLine("\n=== EXERCISE 6: Prize Selection ===");

    short pick1to3 = GetNumInput("Pick a number from 1 to 3:", 1, 3);

    switch (pick1to3)
    {
        case 1:
            Console.Write("You got a new ");
            HighlightColor("car");
            Console.WriteLine("!");
            break;
        case 2:
            Console.Write("You got a new ");
            HighlightColor("plane");
            Console.WriteLine("!");
            break;
        case 3:
            Console.Write("You got a new ");
            HighlightColor("bike");
            Console.WriteLine("!");
            break;
    }
    // can't have default, error handling is done in the helper method
}

#endregion
//=====================================================

//=====================================================
// MAIN MENU
//=====================================================

bool continueRunning = true;

while (continueRunning)
{
    //prewrapped menu
    Console.WriteLine(@"
    +============================================+
    |                                            |
    |  SELECT AN EXERCISE TO RUN:                |
    |                                            |
    |  1 - Exercise 4: Apple Basket Calculator   |
    |  2 - Exercise 5: Compare Two Numbers       |
    |  3 - Exercise 6: Prize Selection           |
    |  0 - Exit                                  |
    |                                            |
    +============================================+
    ");

    short input = GetNumInput("Enter your choice:", 0, 3);

    switch (input)
    {
        case 1:
            Exercise4();
            break;
        case 2:
            Exercise5();
            break;
        case 3:
            Exercise6();
            break;
        case 0:
            continueRunning = false;
            Console.WriteLine("Goodbye!");
            break;
    }
    //can't have default
}

//Console.ReadKey(); //prevents console from closing