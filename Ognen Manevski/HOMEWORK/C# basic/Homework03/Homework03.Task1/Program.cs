using Homework03.Utilities;

//===============================================
#region Exercise 1
//===============================================

//EXERCISE 1
static void Exercise1()
{
    Console.WriteLine("============ EXERCISE 1 =============");

    //Get an input number from the console
    //Print all numbers from 1 up to that number

    int n1 = Utilities.GetNumInput("Print all numbers from 1 up to: ");

    for (int i = 1; i <= n1; i++)
    {
        Utilities.HighlightColor(i.ToString());
        Console.Write(i < n1 ? ", " : "");
    }
    Console.WriteLine();

    //Get another input number from the console
    //Print all numbers starting from that number up to 1

    int n2 = Utilities.GetNumInput("Print all numbers down to 1, starting from: ");

    for (int i = n2; i >= 1; i--)
    {
        Utilities.HighlightColor(i.ToString());
        Console.Write(i > 1 ? ", " : "");
    }
    Console.WriteLine();

    //Get an input number from the console
    //Print all even numbers starting from 2

    int n3 = Utilities.GetNumInput("Print all even numbers starting from 2 up to: ");

    for (int i = 2; i <= n3; i += 2)
    {
        Utilities.HighlightColor(i.ToString());
        Console.Write(i + 2 <= n3 ? ", " : "");
    }
    Console.WriteLine();

    //Get another input number from the console
    //Print all odd numbers starting from 1

    int n4 = Utilities.GetNumInput("Print all odd numbers starting from 1 up to: ");

    for (int i = 1; i <= n4; i += 2)
    {
        Utilities.HighlightColor(i.ToString());
        Console.Write(i < n4 - 1 ? ", " : "");
    }
    Console.WriteLine();
}

#endregion
//===============================================



//===============================================
#region Exercise 2
//===============================================

//EXERCISE 2

//Get an input from the console
//Print all numbers from 1 to that number

//Don’t print numbers that can be divided by 3 or 7

//If the number gets to 100 print a message:
//The limit is reached
//and stop counting

static void Exercise2()
{
    Console.WriteLine("============ EXERCISE 2 =============");

    Console.WriteLine("Print all numbers from 1 up to [Your Input], \nexcluding those divisable by 3 or 7.");
    int n = Utilities.GetNumInput("Enter a number to count up to:");

    for (int i = 1; i <= n; i++)
    {
        if (i % 3 == 0 || i % 7 == 0)
        {
            Console.WriteLine("Can't print this number");
            continue;
        }

        if (i == 100)
        {
            Console.WriteLine("The limit is reached");
            break;
        }

        Utilities.HighlightColor(i.ToString() + "\n");
    }
}

#endregion
//===============================================




//===============================================
#region Exercise 3
//===============================================

//EXERCISE 3

//Declare 5 arrays with 5 elements in them:
//    With words
//    With decimal values
//    With characters from keyboard
//    With true/false values
//    With arrays, each holding 2 whole numbers

static void Exercise3()
{
    Console.WriteLine("============ EXERCISE 3 =============");

    string[] words = { "Word1", "Word2", "Word3", "Word4", "Word5" };
    double[] decimals = { 1.1, 2.2, 3.3, 4.4, 5.5 };
    char[] characters = { 'A', 'b', 'C', 'd', 'E' };
    bool[] trueFalse = { true, false, true, false, true };
    //easy way
    int[][] arrayOfArrays = [[1, 1], [2, 2], [3, 3], [4, 4], [5, 5]];
    //hard way
    int[][] arrayOfArrays2 = new int[5][]
    {
        new int[] {10, 10},
        new int[] {20, 20},
        new int[] {30, 30},
        new int[] {40, 40},
        new int[] {50, 50}
    };

    //T is a placeholder for any type of variable
    static void PrintArr<T>(T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Utilities.HighlightColor(arr[i].ToString());
            if (i < arr.Length - 1) Console.Write(", ");
        }
        Console.WriteLine();
    }

    // For Arrays of Arrays
    static void PrintArrOfArrs(int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("[");
            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write("[");
                Utilities.HighlightColor(arr[i][j].ToString());
                Console.Write("]");
                if (j < arr[i].Length - 1) Console.Write(", ");
            }
            Console.Write("]");
            if (i < arr.Length - 1) Console.Write(", ");
        }
        Console.WriteLine();
    }

    Console.WriteLine("Printing the arrays:");

    PrintArr(words);
    PrintArr(decimals);
    PrintArr(characters);
    PrintArr(trueFalse);
    PrintArrOfArrs(arrayOfArrays);
    PrintArrOfArrs(arrayOfArrays2);

}

#endregion
//===============================================



//===============================================
#region Exercise 4
//===============================================

//EXERCISE 4

//Declare a new array of integers with 5 elements
//Initialize the array elements with values from input
//Sum all the values and print the result in the console

static void Exercise4()
{
    Console.WriteLine("============ EXERCISE 4 =============");
    int[] ints = new int[5];

    Console.WriteLine("Please enter 5 numbers:");

    int sum = 0;

    for (int i = 0; i < ints.Length; i++)
    {
        ints[i] = Utilities.GetNumInput($"Enter number {i + 1}:");
        sum += ints[i];
    }

    Console.Write("The sum of the numbers ");

    for (int i = 0; i < ints.Length; i++)
    {
        Console.Write(ints[i]);
        if (i < 3) Console.Write(", ");
        if (i == 3) Console.Write(" and ");
    }

    Console.Write(" is: ");
    Utilities.HighlightColor(sum.ToString() + "\n");
}

#endregion
//===============================================




//===============================================
#region Exercise 5
//===============================================

//EXERCISE 5

//Create an array with names
//Give an option to the user to enter a name from the keyboard
//After entering the name put it in the array
//Ask the user if they want to enter another name(Y / N)
//Do the same process over and over until the user enters N
//Print all the names after user enters N

static void Exercise5()
{
    Console.WriteLine("============ EXERCISE 5 =============");

    string[] names = new string[0];

    bool done = false;

    do
    {
        Console.WriteLine("Please enter a name:");
        string input = Console.ReadLine();
        Array.Resize(ref names, names.Length + 1);
        names[names.Length - 1] = input;

        Console.WriteLine("Do you want to enter another name? (Y/N)");
        string answer = Console.ReadLine();

        if (answer.ToUpper() == "N")
        {
            done = true;
        }

    } while (!done);

    for (int i = 0; i < names.Length; i++)
    {
        Utilities.HighlightColor(names[i]);
        Console.Write(i < names.Length - 1 ? ", " : "\n");
    }

}

#endregion
//===============================================



//===============================================
#region Main Menu
//===============================================

bool Exit = false;

while (!Exit)
{
    Console.WriteLine("============ MAIN MENU ============");
    Console.WriteLine("1: Exercise 1");
    Console.WriteLine("2: Exercise 2");
    Console.WriteLine("3: Exercise 3");
    Console.WriteLine("4: Exercise 4");
    Console.WriteLine("5: Exercise 5");
    Console.WriteLine("0: Exit");
    Console.WriteLine("===================================");

    int input = Utilities.GetNumInput("Pick an Exercise to run:");

    switch (input)
    {
        case 1: Exercise1(); break;
        case 2: Exercise2(); break;
        case 3: Exercise3(); break;
        case 4: Exercise4(); break;
        case 5: Exercise5(); break;
        case 0:
            Exit = true;
            Console.WriteLine("Goodbye!");
            break;
        default:
            continue;
    }
}

#endregion
//===============================================
