//Task 3:

//Create new console application called “SwapNumbers”.
//Input 2 numbers from the console and then swap the values of the variables
//so that the first variable has the second value and the second variable the first value.
//Please find example below:

//    Test Data:
//        Input the First Number: 5
//        Input the Second Number: 8
//    Expected Output:
//        After Swapping:
//        First Number: 8
//        Second Number: 5

using Homework02.Utilities;

Console.WriteLine("============== Task 3: Swap Numbers ==================");

double n1 = Utilities.GetNumInput("Input the First Number: ");
double n2 = Utilities.GetNumInput("Input the Second Number: ");

Console.Write("You entered: number1: ");
Utilities.HighlightColor(n1.ToString());
Console.Write(", number2: ");
Utilities.HighlightColor(n2.ToString());
Console.WriteLine();

double temp = n1;
n1 = n2;
n2 = temp;

Console.Write("After Swapping: number1: ");
Utilities.HighlightColor(n1.ToString());
Console.Write(", number2: ");
Utilities.HighlightColor(n2.ToString());
Console.WriteLine();