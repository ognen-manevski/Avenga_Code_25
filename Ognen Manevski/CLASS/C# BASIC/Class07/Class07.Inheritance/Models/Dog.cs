
namespace Class07.Inheritance.Models;

public class Dog : Animal // : means inheritance, Dog is inheriting from Animal
{
    public string Race { get; set; }


    public Dog()
    {
        Console.WriteLine("A new istance of a Dog is created and also called the default (empty) Parent Constructor.");
        Thread.Sleep(1000);
    }

    public void Bark()
    {
        Console.WriteLine("Woof Woof Woof!");
    }

    public override void Eat() // override means that we are overriding the method from the parent class
    {
        Console.WriteLine($"Hi people i am {Name} the {Type} and I am eating dog food.");
        //base.Eat(); //the default
    }
}
