//==========================================
#region Exercise 1
//==========================================

Console.WriteLine("========== Exercise 1 ============");

//Get an input number from the console
//Print all numbers from 1 up to that number

Console.WriteLine("Enter a number [Up To]:");
if (int.TryParse(Console.ReadLine(), out int upTo))
{
    for (int i = 1; i <= upTo; i++)
    {
        Console.WriteLine(i);
    }
}

//Get another input number from the console
//Print all numbers starting from that number up to 1

Console.WriteLine("Enter a number [From]:");
if (int.TryParse(Console.ReadLine(), out int from))
{
    for (int i = from; i >= 1; i--)
    {
        Console.WriteLine(i);
    }
}

//Get an input number from the console
//Print all even numbers starting from 2

Console.WriteLine("Enter a number [Even]:");
if (int.TryParse(Console.ReadLine(), out int even))
{
    for (int i = 2; i <= even; i += 2)
    {
        Console.WriteLine(i);
    }
}

//Get another input number from the console
//Print all odd numbers starting from 1

Console.WriteLine("Enter a number [Odd]:");
if (int.TryParse(Console.ReadLine(), out int odd))
{
    for (int i = 1; i <= odd; i += 2)
    {
        Console.WriteLine(i);
    }
}

#endregion
//==========================================

//==========================================
#region Exercise 2
//==========================================

Console.WriteLine("========== Exercise 2 ============");

//Get an input from the console
//Print all numbers from 1 to that number

//Don’t print numbers that can be divided by 3 or 7

//If the number gets to 100 print a message:
//The limit is reached
//and stop counting

Console.WriteLine("Enter a number [Limit]:");
if (int.TryParse(Console.ReadLine(), out int limit))
{
    for (int i = 1; i <= limit; i++)
    {
        {
            continue;
        }

        if (i == 100)
        {
            Console.WriteLine("The limit is reached");
            break;
        }

        Console.Write(i + ", ");
    }
}

#endregion
//==========================================