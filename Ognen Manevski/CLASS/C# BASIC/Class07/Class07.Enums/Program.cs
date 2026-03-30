using Class07.Enums.Enums;

Console.WriteLine(DaysOfWeek.Monday);
Console.WriteLine(Convert.ToInt32(DaysOfWeek.Monday)); // number (id) //explicitly set to 1

Console.WriteLine("Please enter day of week:");
string userInput = Console.ReadLine();

//bad way:
//if (userInput == "Saturday" || userInput == "Sunday")
//{
//    Console.WriteLine("Yeey! It is the weekend!");
//}

//better way:
if (userInput == DaysOfWeek.Saturday.ToString() || userInput == DaysOfWeek.Sunday.ToString())
{
    Console.WriteLine("Yeey! It is the weekend!");
}