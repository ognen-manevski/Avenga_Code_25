
using Class09.ErrorHandling.Models;
using System.Reflection.PortableExecutable;

Console.WriteLine("  ------------ Example 1  ------------ ");
//handling .net exception

try
{

    Console.WriteLine("Enter a number:");
    int number = Int32.Parse(Console.ReadLine()); // int32 is the same as int, but it is more explicit
                                                  // and can be useful for clarity in some cases.
                                                  // The Parse method converts the string "123" into an integer value of 123.
                                                  // If the string cannot be parsed into an integer, it will throw a FormatException.

    Console.WriteLine($"The number you entered is {number}");

}
catch (Exception ex)
{

    Console.WriteLine($"Oops, something went wrong!. Please try again later. ");
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"Info for developer : {ex.Message}");
    Console.WriteLine($"{ex.StackTrace}");
}
finally
{
    Console.WriteLine("  ------------ Press any key to continue  ------------ ");
}


//custom exception // with our own logic

Console.WriteLine("  ------------ Example 2  ------------ ");
Console.WriteLine("Handling exception with custom messsage");

try
{
    Console.WriteLine("Enter letter A or letter B:");

    string letter = Console.ReadLine().Trim().ToLower();

    if (letter == "a" && letter == "b")
    {
        Console.WriteLine("Gratz, you have entered A or G");
    }
    else
    {
        throw new Exception("That is not A or B, sorry.");
    }


}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
    Console.WriteLine("More info: " + ex.InnerException);
}
finally
{
    Console.WriteLine("  ------------ Press any key to continue  ------------ ");
    Console.ReadLine();
}


#region handling specific exceptions 


Console.WriteLine("  ------------ Example 3  ------------ ");


try
{
    Console.WriteLine("Enter some character:");
    char char1 = char.Parse(Console.ReadLine());
    Console.WriteLine($"The character you entered is: [{char1}].");
    Console.WriteLine("Somethingething else");


    int number1 = Int32.Parse(Console.ReadLine());
    Console.WriteLine($"The number you entered is: [{number1}].");

    Person p = new Person() { Name = "John Doe" };
    foreach (var skill in p.Skills)
    {
        Console.WriteLine(skill);
    }


}
catch (FormatException frmEx)
{

    Console.WriteLine("You have entered something other than a character!");
}

catch (OverflowException ovEx)
{
    Console.WriteLine("You have entered either too large or too small number.");
}

catch (Exception ex) // catch all other exceptions that are not handled by the previous catch blocks
{
    Console.WriteLine("An unexpected error occurred: " + ex.Message);
}

finally
{
    Console.WriteLine("  ------------ Press any key to continue  ------------ ");
    Console.ReadLine();
}


#endregion


#region handling exceptions within a method


Console.WriteLine("  ------------ Example 4  ------------ ");

//exception handling propagation
// (exception sent to the higher level)



static void PersonSkill1(Person person)
{
    foreach (var skill in person.Skills)
    {
        Console.WriteLine(skill);
    }
}


static void PersonSkill2(Person person)
{
    try
    {
        foreach (var skill in person.Skills)
        {
            Console.WriteLine(skill);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Catch inside the function : {ex.Message}");
        Console.WriteLine("More info: " + ex.Message);
    }
}


try
{

    PersonSkill1(new Person() { Name = "John Doe" });
    PersonSkill2(new Person() { Name = "Joane Doe" });
}
catch (NullReferenceException ex)
{

    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("  ------------ Press any key to continue  ------------ ");
    Console.ReadLine();
}


#endregion