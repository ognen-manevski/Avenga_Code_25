//Task 1
//Make a console application called SumOfEven.
//Inside it create an array of 6 integers.
//Get numbers from the input, find and print the sum of the even numbers from the array:

//    Test Data:
//        Enter integer no.1:
//            4
//        Enter integer no.2:
//            3
//        Enter integer no.3:
//            7
//        Enter integer no.4:
//            3
//        Enter integer no.5:
//            2
//        Enter integer no.6:
//            8
//    Expected Output:
//        The result is: 14


using Homework03.Utilities;

int[] numbersArr = new int[6];


Console.WriteLine("================ Sum of Even Numbers ==============");

Console.WriteLine("Please enter 6 numbers below.");

static int GetNumberInput(string msg)
{
    Console.WriteLine(msg);
    while (true)
    {
        bool tryNumber = int.TryParse(Console.ReadLine(), out int input);

        if (tryNumber == false || tryNumber == null)
        {
            Console.WriteLine("Invalid input. Please enter a valid number:");
            continue;
        }
        return input;
    }
}

for (int i = 0; i < 6; i++)
{
    numbersArr[i] = GetNumberInput($"Enter number [{i + 1}]: ");
}

int sum = 0;
foreach (int n in numbersArr)
{
    if (n % 2 == 0)
    {
        sum += n;
    }
}

Console.Write("The result is: ");
Utilities.HighlightColor(sum.ToString());