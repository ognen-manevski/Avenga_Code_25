//Task 2
//Create new console application called “AverageNumber” that takes four numbers as input to calculate and print the average.

//    Test Data:
//        Enter the First number: 10
//        Enter the Second number: 15
//        Enter the third number: 20
//        Enter the four number: 30
//    Expected Output:
//        The average of 10, 15, 20 and 30 is: 18


using Homework02.Utilities;

Console.WriteLine("============== Task 2: Average Number ==================");

double n1 = Utilities.GetNumInput("Enter the first number:");
double n2 = Utilities.GetNumInput("Enter the second number:");
double n3 = Utilities.GetNumInput("Enter the third number:");
double n4 = Utilities.GetNumInput("Enter the fourth number:");

double avg = (n1 + n2 + n3 + n4) / 4;

Console.Write("The average of ");
Utilities.HighlightColor(n1.ToString());
Console.Write(", ");
Utilities.HighlightColor(n2.ToString());
Console.Write(", ");
Utilities.HighlightColor(n3.ToString());
Console.Write(" and ");
Utilities.HighlightColor(n4.ToString());
Console.Write(" is: ");
Utilities.HighlightColor(avg.ToString());
Console.WriteLine();