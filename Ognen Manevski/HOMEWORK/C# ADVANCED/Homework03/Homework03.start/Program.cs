/*
Class 3 Homework 📒
Task 1

Create class User that will have 3 properties Id, Name, Age.
Create static class UserDatabase that will contain a list of Users (create couple of users and add them to the list).
Create method (or methods) Search() that will search the UserDatabase by Id, Name and Age and will return users as a result.
Task 2

Create a class Vehicle that have one method DisplayInfo(). Create class Car, MotorBike, Boat, Airplane that will inherit from Vehicle and will implement the respective method;

Vehicle car = new Car();
Vehicle motorBike = new MotorBike();
Vehicle boat = new Boat();
Vehicle plane = new Airplane();

car.DisplayInfo();
motorBike.DisplayInfo();
boat.DisplayInfo();
plane.DisplayInfo()

// in console we should display
// Im a car and i drive on 4 wheels :)
// Im a motorbike and i drive on 2 wheels :)
// Im a boat and i do not have wheels :(
// Im a plane i have couple of wheels :)

*/

using Homework03.name.BaseEntities;
using Homework03.name.Classes;


//task1

//helper

void FormatUserInfo(User? user)
{
    if (user != null)
    {
        Console.WriteLine($"| ID: {user.Id} | Name: {user.Name} | Age: {user.Age} |");
    }
    else
    {
        Console.WriteLine("User not found.");
    }
}

Console.WriteLine($"Search user by [id=2]:");
FormatUserInfo(UserDatabase.Search(2));
Console.WriteLine();

Console.WriteLine($"Search user by [name='Alice']:");
List<User> usersNamedAlice = UserDatabase.Search("Alice");
foreach (var user in usersNamedAlice)
{
    FormatUserInfo(user);
}
Console.WriteLine();

Console.WriteLine($"Search user by [id=1 + name=\"John\" + age= 30]:");
FormatUserInfo(UserDatabase.Search(1, "John", 30));
Console.WriteLine();


//task 2

Vehicle car = new Car();
Vehicle motorBike = new MotorBike();
Vehicle boat = new Boat();
Vehicle plane = new Airplane();

car.DisplayInfo();
motorBike.DisplayInfo();
boat.DisplayInfo();
plane.DisplayInfo();