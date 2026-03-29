using Homework05.Homework_Cars_Drivers.Models;


//======================================================
#region Task Description
//======================================================

//Homework Class 5 📒
//Task 1

//    Make a class Driver. Add properties: Name, Skill

//    Make a class Car. Add properties: Model, Speed and Driver

//    Make a method of the Car class called : CalculateSpeed()
//    that takes a driver object as input parameter and calculates the skill
//    multiplied by the speed of the car and return it as a result.

//    Make a method RaceCars() that will get two Car
//    objects that will determine which car will win and print the result in the console.

//    Make 4 car objects and 4 driver objects.

//    Ask the user to select a two cars and two drivers for the cars.Add the drivers to the cars and call the RaceCars() methods
//    Test Data:
//        Choose a car no.1:
//            Hyundai
//            Mazda
//            Ferrari
//            Porsche
//        Choose Driver:
//            Bob
//            Greg
//            Jill
//            Anne
//        Choose a car no.2:
//            Hyundai
//            Mazda
//            Ferrari
//            Porsche
//        Choose Driver:
//            Bob
//            Greg
//            Jill
//            Anne
//    Expected Output:
//        Car no. 2 was faster.


//    BONUS 1: If a user chooses option one for the first car, eliminate that option when the user picks car two.

//    BONUS 2: Make the Output message say what was the model of the car that won, what speed was it going and which driver was driving it.

//    BONUS 3: Implement a Race Again Feature where you ask the user if he wants to race again and repeat the racing function.


#endregion
//======================================================

//initialize object arrays
Car[] cars;
Driver[] drivers;

void initCarsAndDrivers()
{
    cars =
    [
     new Car("Hyundai", 200),
     new Car("Mazda", 220),
     new Car("Ferrari", 240),
     new Car("Porsche", 260)
    ];

    drivers =
    [
        new Driver("Bob", 1.1),
        new Driver("Greg", 1.2),
        new Driver("Jill", 1.3),
        new Driver("Anne", 1.4)
    ];
}

//game loop
while (MainMenu())
{
    Console.Clear();
}

bool MainMenu()
{
    Console.WriteLine("=========== Homework - Cars & Drivers ===========");

    //init/reset
    initCarsAndDrivers();

    //player1
    PrintCars();
    int p1CarNo = GetNumInput("Player [1] pick a car:", cars.Length);
    Car p1Car = cars[p1CarNo - 1];
    PrintDrivers();
    int p1DriverNo = GetNumInput("Player [1] pick a driver:", drivers.Length);
    Driver p1Driver = drivers[p1DriverNo - 1];

    //player2
    PrintCars(p1Car);
    int p2CarNo = GetNumInput("Player [2] pick a car:", cars.Length, p1CarNo);
    Car p2Car = cars[p2CarNo - 1];
    PrintDrivers(p1Driver);
    int p2DriverNo = GetNumInput("Player [2] pick a driver:", drivers.Length, p1DriverNo);
    Driver p2Driver = drivers[p2DriverNo - 1];

    //start race
    RaceCars(p1Car, p1Driver, p2Car, p2Driver);

    return PlayAgain();
}

bool PlayAgain()
{
    Console.WriteLine("------------------ Play again? ------------------");
    Console.WriteLine("Press [Y] to play again or any other key to exit.");

    if (Console.ReadLine().ToUpper() == "Y") return true;

    Console.WriteLine("Thanks for playing!");
    return false;
}

//main logic
void RaceCars(Car car1, Driver driver1, Car car2, Driver driver2)
{
    double speed1 = car1.CalculateSpeed(driver1);
    double speed2 = car2.CalculateSpeed(driver2);

    if (speed1 > speed2)
    {
        WinnerMsg(1, car1, driver1, speed1);
    }
    else if (speed2 > speed1)
    {
        WinnerMsg(2, car2, driver2, speed2);
    }
    else
    {
        Console.WriteLine("It's a tie!");
    }
}

//======================================================
#region Helpers
//======================================================

int GetNumInput(string msg, int limit = 0, int taken = 0)
{
    Console.WriteLine(msg);
    int reply = 0;
    bool ok = false;


    while (!ok)
    {
        bool tryInput = int.TryParse(Console.ReadLine(), out reply);

        if (tryInput == false || reply == 0)
        {
            Console.WriteLine("Invalid input, try again:");
            continue;
        }
        if (taken != 0 && reply == taken)
        {
            Console.WriteLine("That one is already taken. Pick something else:");
            continue;
        }
        if (limit > 0 && reply > limit)
        {
            Console.WriteLine("Input out of range, try again:");
            continue;
        }
        ok = true;
    }
    return reply;
}

void PrintCars(Car delete = null)
{
    Console.WriteLine($"+{new string('-', 10)} Cars {new string('-', 10)}+");
    int i = 0;
    foreach (Car car in cars)
    {
        i++;
        if (car == delete) continue;
        Console.WriteLine($"| {i}. {car.Model,-22} |");
    }
    Console.WriteLine($"+{new string('-', 26)}+");
}

void PrintDrivers(Driver delete = null)
{
    Console.WriteLine($"+{new string('-', 9)} Drivers {new string('-', 9)}+");
    int i = 0;
    foreach (Driver driver in drivers)
    {
        i++;
        if (driver == delete) continue;
        Console.WriteLine($"| {i}. {driver.Name,-22} |");
    }
    Console.WriteLine($"+{new string('-', 27)}+");
}

void WinnerMsg(int player, Car car, Driver driver, double speed)
{
    Console.WriteLine();
    Console.WriteLine(
            @$"Player[{player}] is the winner!
| Car Model: {car.Model} | Driver: {driver.Name} | Average Speed: {speed}km/h |"
        );
    Console.WriteLine();
}

#endregion
//======================================================
