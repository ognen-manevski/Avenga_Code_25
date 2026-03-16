//==========================================
#region Data Entry
//==========================================

using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Please enter something:");

string userInput = Console.ReadLine(); //stops the program

Console.WriteLine("User Input: " + userInput);

//

Console.WriteLine("Please number 1:");
//var number1 = Console.ReadLine(); //must be var or string
//int number1 = int.Parse(Console.ReadLine());
//int number1 = Convert.ToInt32(Console.ReadLine());
bool isParsedNum1 = int.TryParse(Console.ReadLine(), out int number1);
//if false number1 will be 0, if true number1 will be the parsed value


Console.WriteLine("Please number 2:");
//int number2 = int.Parse(Console.ReadLine());
//int number2 = Convert.ToInt32(Console.ReadLine());
bool isParsedNum2 = int.TryParse(Console.ReadLine(), out int number2);


#endregion
//==========================================




//==========================================
#region If Else , switch
//==========================================

if (!isParsedNum1 || !isParsedNum2)
{
    Console.WriteLine("You try to sum values that arent numbers");
    return;
}

Console.WriteLine("Number1 + Number2:");
Console.WriteLine(number1 + number2);


//switch

Console.WriteLine("Enter a day of the week and I will let you know if you have classes:");

string dayOfWeek = Console.ReadLine().ToLower();

switch (dayOfWeek)
{
    case "monday":
    case "wednesday":
    case "friday":
        Console.WriteLine("You Have Classes Today");
        break;
    case "tuesday":
    case "thursday":
    case "saturday":
    case "sunday":
        Console.WriteLine("No classes");
        break;
    default:
        Console.WriteLine("No such day, try again!");
        break;
}


#endregion
//==========================================



