
namespace Homework05.ClassExercises.Models;

internal class Dog
{
    public string Name { get; set; }
    public string Race { get; set; }
    public string Color { get; set; }


    public Dog(string name, string race, string color)
    {
        Name = name;
        Race = race;
        Color = color;
    }   


    public void Eat()
    {
        Console.WriteLine("The dog is now eating.");
    }

    public void Play()
    {
        Console.WriteLine("The dog is now playing.");
    }

    public void ChaseTail()
    {
        Console.WriteLine("The dog is now chasing its tail.");
    }

    //for experimenting
    public void ViewDetails()
    {
        Console.WriteLine($"Name: {Name} | Race: {Race} | Color: {Color}");
    }


}
