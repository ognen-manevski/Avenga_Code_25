
namespace Homework05.ClassExercises.Models;

internal class Human
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Age { get; set; }

    public Human(string firstName, string lastName, string age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }


    public string GetPersonStats()
    {
        return $"The human {FirstName} {LastName} is {Age} years old ";
    }
}
