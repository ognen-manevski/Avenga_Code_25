namespace Class07.Inheritance.Models;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public Animal()
    {
        Console.WriteLine("A new instance of an animal has been created.");
        Console.WriteLine("This is the Animal EMPTY constructor.");
        Thread.Sleep(1000);
    }

    public Animal(string type)
    {
        Type = type;
        Console.WriteLine($"A new instance of an animal of type {type} has been created.");
        Console.WriteLine("This is the Animal constructor with TYPE parameter.");
        Thread.Sleep(1000);
    }

    public Animal(int id, string name, string type)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    public virtual void Eat() // virtual means that this method can be overridden in the child class
    {
        Console.WriteLine($"The {Type} animal named {Name} is eating.");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Id: {Id}, Animal: {Type}, Name: {Name}.");
    }



}
