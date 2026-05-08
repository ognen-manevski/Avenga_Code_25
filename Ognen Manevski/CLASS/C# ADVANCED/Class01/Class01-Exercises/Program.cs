
using Class01_Exercises;

void HelloWorld()
{
    Console.WriteLine("Hello, World!");
}

HelloWorld();

Console.ReadLine();

Developer mario = new Developer("Mario", "Rossi", 30);
Console.WriteLine(mario.GetNumberOfDevelopers());

Console.WriteLine(Developer.NumberOfDevelopers);

Console.WriteLine(mario.GetNumberOfDevelopers());


//mario.ResetNumberOfDevelopers(); -- wont work
Developer.ResetNumberOfDevelopers(); // works because its static
Console.WriteLine(mario.GetNumberOfDevelopers());