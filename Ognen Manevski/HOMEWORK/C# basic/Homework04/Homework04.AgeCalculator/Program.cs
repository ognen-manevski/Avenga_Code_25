//Homework Class 4 📒
//Task

//    Make a method called AgeCalculator
//    The method will have one input parameter, your birthday date
//    The method should return your age
//    Show the age of a user after he inputs a date

//    Note: take into consideration if the birthday is today, after or before today

Console.WriteLine("============== Age Calculator ==============");

static string AgeCalculator(DateTime bday)
{
    DateTime now = DateTime.Now;

    if (bday.Date > now.Date)
    {
        return "future";
    }

    if (bday.Date == now.Date || bday.Date >= now.AddYears(-1).Date)
    {
        return "0";
    }

    int years = now.Year - bday.Year;
    int months = now.Month - bday.Month;
    int days = now.Day - bday.Day;

    // copilot adjustments with explanation:

    // Adjust for negative days
    if (days < 0)
    {
        months--;

        // Get the number of days in the previous month
        // If the current month is January, we need to look at December of the previous year
        // and add the days to the negative current days
        if (now.Month == 1)
        {
            //.DaysInMonth(year, month) -> returns the days in the specified month and year
            days += DateTime.DaysInMonth(now.Year - 1, 12);
        }
        else
        {
            // For other months, we look at the previous month of the current year
            days += DateTime.DaysInMonth(now.Year, now.Month - 1);
        }
    }

    // Adjust for negative months
    if (months < 0)
    {
        years--;
        months += 12; // Add 12 months to adjust for the negative month
    }

    string formatedAge = string.Format($"You are {days} days, {months} months and {years} years old.");

    return formatedAge;
}


Console.WriteLine("Please enter your birthday in the format [dd/MM/yyyy].");
Console.WriteLine("You can use /, -, ., or space as a separator.");

while (true)
{
    string dateInput = Console.ReadLine();

    bool tryDate = DateTime.TryParse(dateInput, out DateTime bday);

    if (tryDate == false)
    {
        Console.WriteLine("Please use a valid date format.");
        continue;
    }

    string age = AgeCalculator(bday);

    if (age == "future")
    {
        Console.WriteLine("That date is in the future.");
        Console.WriteLine("Please enter a valid date:");
        continue;
    }

    if (age == "0")
    {
        Console.WriteLine("You can't be 0 years old.");
        Console.WriteLine("Please enter a valid date:");
        continue;
    }

    Console.WriteLine(age);
    return;
}
