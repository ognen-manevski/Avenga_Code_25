namespace Class07.Inheritance.Models;

internal class Cat : Animal
{
    public string Lazyness { get; set; } = "Very lazy"; //default


    public Cat() : base("Cat") // this is calling the constructor of the parent class (Animal)
                               // specifically the one that takes a string as a parameter
    {
        Console.WriteLine("A new cat has been created.");
        Console.WriteLine("Using the constructor that requires a string.");
    }

    public void Meow()
    {
        Console.WriteLine("Meow Meow Meow!");
    }

    public override void Eat()
    {
        Console.WriteLine($"You don't tell a cat when to eat.");       
        Console.WriteLine($"A cat eats when it wants.");       
    }



}
