//=============================================
#region  EXERCISE 3
//=============================================

//EXERCISE 3

//In the existing Console Application:

//    Create a new method called Substrings
//    Inside the method use the string:
//    "Hello from Avenga Codecademy 2024"
//    Ask the user to enter a number n
//    Print the first n characters
//    Print the length of the new string
//    Try to handle all scenarios

static void Substrings()
{
    Console.WriteLine("========== Exercise 3 - Substrings ========");

    string hello = "Hello from Avenga Codecademy 2024";

    Console.WriteLine("How many characters from the string:");
    Console.WriteLine($"\"{hello}\"");
    Console.WriteLine($"do you want to print? [1 to {hello.Length}]");

    int num = 1;
    bool invalidInput = true;

    while (invalidInput)
    {
        bool tryNum = int.TryParse(Console.ReadLine(), out num);

        if (tryNum == false)
        {
            Console.WriteLine("That is not a number, try again:");
            continue;
        }

        if (num > hello.Length || num < 1)
        {
            Console.WriteLine($"Invalid range, please pick from 1 to {hello.Length}:");
            continue;
        }

        invalidInput = false;
    }

    //method 1
    //for(int i = 0; i <= num; i++)
    //{
    //    Console.Write(hello[i]);
    //}
    //Console.WriteLine();

    //method 2
    string substring = hello.Substring(0, num);
    Console.WriteLine($"The substring: \"{substring}\"");
    Console.WriteLine($"Is: {substring.Length} characters long.");
}
Substrings();


#endregion
//=============================================



//=============================================
#region EXERCISE 4
//=============================================

//EXERCISE 4

Console.WriteLine("========== Exercise 4  ========");

DateTime now = DateTime.Now;
Console.WriteLine($"Current Date (for reference): {FormatDate(now)}.");

//Print the date that is 3 days from now
Console.WriteLine($"3 days from now it will be: {FormatDate(now.AddDays(3))}.");

//Print the date that is 1 month from now
Console.WriteLine($"1 month from now it will be: {FormatDate(now.AddMonths(1))}.");

//Print the date that is 1 month and 3 days from now
Console.WriteLine($"1 month and 3 days from now it will be: {FormatDate(now.AddMonths(1).AddDays(3))}.");

//Print the date 1 year and 2 months ago
Console.WriteLine($"1 year and 2 months ago it was: {FormatDate(now.AddYears(-1).AddMonths(-2))}.");

//Print only the current month
Console.WriteLine($"The current month is: {now.ToString("MMMM")}.");

//Print only the current year
Console.WriteLine($"The current year is: {now.Year}.");

//helper for formating the date without the time
static string FormatDate(DateTime date)
{
    return date.ToString("dd/MM/yyyy");
}

#endregion
//=============================================