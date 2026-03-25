
using Class05.Exercises.Models;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

//Exercise 1 

//Create a class Human.
//Add properties:
//FirstName
//LastName
//Age
//Create a method GetPersonStats that:
//Returns the full name
//Returns the age
//Ask the user for input, create an object and print the result in the console.

static void Exercise1()
{

    Console.WriteLine("========== Exercise 1 ==========");

    Console.WriteLine("Please write the person's first name");
    string fname = Console.ReadLine();

    Console.WriteLine("Please write the person's last name");
    string lname = Console.ReadLine();

    Console.WriteLine("Please write the person's age");
    string age = Console.ReadLine();

    Human person = new Human(fname, lname, age);

    Console.WriteLine(person.GetPersonStats());
}


//EXERCISE 2
//Create a class Dog.

//Add properties:

//Name
//Race
//Color
//Add methods:

//Eat → prints “The dog is now eating.”
//Play → prints “The dog is now playing.”
//ChaseTail → prints “The dog is now chasing its tail.”
//Ask the user to:

//Enter dog data
//Choose one of the actions
//Call the selected method.

