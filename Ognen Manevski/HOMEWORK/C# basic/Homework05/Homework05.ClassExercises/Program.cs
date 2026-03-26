using Homework05.ClassExercises.Models;

//===============================================
#region Exercise 1
//===============================================

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
Exercise1();

#endregion
//===============================================

//===============================================
#region Exercise 2
//===============================================

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

static void Exercise2()
{
    Console.WriteLine("========== Exercise 2 ==========");

    Dog dog = CreateDog();

    Console.WriteLine($"You now have a pet dog named {dog.Name}");

    bool exit = false;

    while (!exit)
    {
        Console.WriteLine("What do you want to do with it now?");
        Console.WriteLine(@$"
        +{new string('-', 17)}+
        | {"1. Eat",-15} |
        | {"2. Play",-15} |
        | {"3. Chase Tail",-15} |
        | {"4. Edit Pet",-15} |
        | {"5. View Details",-15} |
        | {"6. Exit",-15} |
        +{new string('-', 17)}+
        ");

        int select = 0;
        bool inputOK = false;

        while (!inputOK)
        {
            bool tryInput = int.TryParse(Console.ReadLine(), out select);

            if (tryInput == false || select < 1 || select > 6)
            {
                Console.WriteLine("Invalid Input. Please pick from the menu. ");
                continue;
            }

            inputOK = true;
        }

        if (select == 6) { exit = true; continue; }

        dog = DoAction(select, dog);
    }
}
Exercise2();

static Dog CreateDog()
{
    Console.WriteLine("Please enter the dog's name:");
    string name = Console.ReadLine();
    Console.WriteLine("Please enter the dog's race");
    string race = Console.ReadLine();
    Console.WriteLine("Please enter the dog's color:");
    string clr = Console.ReadLine();

    Dog dog = new Dog(name, race, clr);
    return dog;
}

static Dog DoAction(int action, Dog dog)
{
    switch (action)
    {
        case 1: dog.Eat(); break;
        case 2: dog.Play(); break;
        case 3: dog.ChaseTail(); break;
        case 4: dog = CreateDog(); break;
        case 5: dog.ViewDetails(); break;
    }
    return dog;
}

#endregion
//===============================================


//===============================================
#region Exercise 3
//===============================================

//EXERCISE 3

//Create a class Student with properties:
//    Name
//    Academy
//    Group

//Create an array with 5 Student objects.

//Ask the user to enter a name:
//    If the student exists → print the information
//    If not → print an error message

static void Exercise3()
{
    Console.WriteLine("========== Exercise 3 ==========");

    Student[] students = new Student[] {
        new Student("John", "Avenga Academy", "G1"),
        new Student("Jane", "Avenga Academy", "G1"),
        new Student("Bob", "Qinshift Academy", "G2"),
        new Student("Alice", "Qinshift Academy", "G2"),
        new Student("Tom", "SEDC", "G3"),
    };

    Console.WriteLine("Please enter a student name:");
    string name = Console.ReadLine();

    int found = 0;

    foreach (Student student in students)
    {
        if (student.Name == name.ToLower())
        {
            Console.Write("Student found: ");
            Console.WriteLine(student.GetInfo());
            found++;
            continue;
        }
    }

    if (found == 0)
    {
        Console.WriteLine($"Couldn't find a student with the name {name}.");
    }
}
Exercise3();


#endregion
//===============================================