
//2.Create a console application that checks if a day is a working day 🔹

//    The app should request for a user to enter a date as an input or multiple inputs
//    The app should then open and see if the day is a working day
//    It should show the user a message whether the date they entered is working or not
//        Weekends are not working
//        1 January, 7 January, 20 April, 1 May, 25 May, 3 August, 8 September, 12 October, 23 October and 8 December are not working days as well
//    It should ask the user if they want to check another date
//        Yes - the app runs again
//        No - the app closes

//🤖 Let’s ask AI

//Prompt:

//How can I check if a date is weekend in C#?

//Refine:

//    "using DateTime"
//    "how to compare dates without year"
//    "best way to store holidays"

//Try:

//What is the best data structure to store fixed holidays in C#?


//storage

using static System.Runtime.InteropServices.JavaScript.JSType;

string pad = new string('=', 10);
string sep = new string('-', 50);
string dateTemplates = "Date Templates: dd/MM/yyyy, dd-MM-yyyy, MM/dd/yyyy, MM-dd-yyyy, yyyy/MM/dd, yyyy-MM-dd";

Dictionary<(int month, int day), string> holidays = new Dictionary<(int month, int day), string>
{
    {(1, 1), "1 January"},
    {(1, 7), "7 January"},
    {(4, 20), "20 April"},
    {(5, 1), "1 May"},
    {(5, 25), "25 May"},
    {(8, 3), "3 August"},
    {(9, 8), "8 September"},
    {(10, 12), "12 October"},
    {(10, 23), "23 October"},
    {(12, 8), "8 December"}
};

//logic
bool IsWeekend(DateTime date)
{
    return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
}

bool IsHoliday(DateTime date)
{
    return holidays.ContainsKey((date.Month, date.Day));
}

void CheckWorkingDay(DateTime date)
{
    if (IsHoliday(date))
    {
        Console.WriteLine($"{date:dd MMMM} is a holiday!");
    }
    else if (IsWeekend(date))
    {
        Console.WriteLine($"{date:dd MMMM} is a weekend!");
    }
    else
    {
        Console.WriteLine($"{date:dd MMMM} is a working day.");
    }
}


//app

Console.WriteLine($"{pad} Holidays Checker {pad}");
Console.WriteLine("Check if the date you enter is a holiday!");

bool exit = false;

while (!exit)
{
    bool inputOk = false;

    string input;

    while (!inputOk)
    {

        Console.WriteLine("Please enter a date:");
        Console.WriteLine(dateTemplates);

        input = Console.ReadLine();

        bool tryInput = DateTime.TryParse(input, out DateTime parsedDate);


        if (!tryInput)
        {
            Console.WriteLine("Invalid date format. Please try again.");
            continue;
        }

        CheckWorkingDay(parsedDate);
        inputOk = tryInput;
    }

    Console.WriteLine("Press [Y] to try again or any key to exit");

    string answer = Console.ReadLine();

    if (answer?.ToLower() != "y")
    {
        exit = true;
    }
}