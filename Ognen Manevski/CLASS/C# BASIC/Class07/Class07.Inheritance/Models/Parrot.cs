namespace Class07.Inheritance.Models;

internal class Parrot : Animal
{
    public string Color { get; set; }

    public Parrot()
    {

    }

    public Parrot(int id, string type, string name, string color)
        : base(id, name, type)
    {
        Color = color;
    }

    public void Fly()
    {
        Console.WriteLine("Wow! I am Flying!");
    }

    public override void Eat()
    {
        Console.WriteLine($"I am {Name} and I am a {Type} who doesn't have time to eat.");
        Console.WriteLine("Because I speak all the time.");
    }

}
