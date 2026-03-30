using Class07.Inheritance.Models;

Animal elephant = new Animal()
{
    Id = 1,
    Name = "Dumbo",
    Type = "Elephant"
};

elephant.PrintInfo();
elephant.Eat();

Console.WriteLine(new string('-', 20));

Dog dog = new Dog()
{
    Id = 2,
    Name = "Spiky",
    Type = "Dog",
    Race = "Labrador"
};

dog.PrintInfo();
dog.Eat();
dog.Bark();

Console.WriteLine(new string('-', 20));

Cat cat = new Cat()
{
    Id = 3,
    Name = "Garfield",
    Lazyness = "Very Lazy"
};

cat.PrintInfo();
cat.Eat();
cat.Meow();

Console.WriteLine(new string('-', 20));

Parrot riki = new Parrot(4, "Parrot", "Riki", "Green");

Parrot miki = new Parrot()
{
    Id = 5,
    Name = "Miki",
    Type = "Parrot",
    Color = "Red"
};

riki.PrintInfo();riki.Eat();riki.Fly();