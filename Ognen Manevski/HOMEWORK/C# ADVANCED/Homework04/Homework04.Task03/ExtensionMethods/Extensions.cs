namespace Homework04.Task03.ExtensionMethods;
using Homework04.Task02.Models;

public static class Extensions
{
    public static void Drive(this Car car)
    {
        Console.WriteLine("The car is driving");
    }

    public static void Wheelie(this MotorBike motorBike)
    {
        Console.WriteLine("The motorbike is driving on one wheel");
    }

    public static void Sail(this Boat boat)
    {
        Console.WriteLine("The boat is sailing");
    }

    public static void Fly(this Plane plane)
    {
        Console.WriteLine("The airplane is flying");
    }
}

//Console output
// The car is driving
// The motorbike is driving on one wheel
// The boat is sailing
// The airplane is flying