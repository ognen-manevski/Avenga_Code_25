using Homework06.LINQ_Practice.Models;

namespace Homework06.LINQ_Practice.Helpers;

public static class PrintHelpers
{
    //custom separator
    private static string sep(char character, int length)
    {
        return new string(character, length);
    }

    public static void GetCarInfo(Car car)
    {
        Console.WriteLine($"| {car.Model,-40} | {car.MilesPerGalon,5} | {car.AccelerationTime,5} | {car.Cylinders,5} | {car.HorsePower,5} | {car.Origin,20} | {car.Weight,10} |");
    }

    public static void PrintCar(this Car car, string title = null) //extends
    {
        Console.WriteLine($"====== {(title != null ? $"Printing: {title}" : ""),-28} ======");
        GetCarInfo(car);
    }


    public static void PrintIterable<T>(this IEnumerable<T> items, string title = null) //extends
    {
        if (!items.Any())
        {
            Console.WriteLine("No items to display.");
            return;
        }

        Console.WriteLine($"+{sep('=', 40)} {(title != null ? $"Printing: {title}" : ""),-28} {sep('=', 40)}+");

        //Table format for Car objects
        if (typeof(T) == typeof(Car))
        {
            //Header:
            Console.WriteLine($"| {"Model",-40} | {"MPG",5} | {"Accel",5} | {"Cyl",5} | {"HP",5} | {"Origin",20} | {"Weight",10} |");
            Console.WriteLine($"| {sep('-', 40)} | {sep('-', 5)} | {sep('-', 5)} | {sep('-', 5)} | {sep('-', 5)} | {sep('-', 20)} | {sep('-', 10)} |");

            foreach (Car car in items.Cast<Car>()) //cast to Car type to access properties
            {
                // Row:
                GetCarInfo(car);
            }
        }

        //Simple list format for other types
        else
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        Console.WriteLine($"+{sep('=', 110)}+");
    }


    public static void PrintGroupedCars(IEnumerable<IGrouping<string, Car>> groups)
    {
        foreach (var group in groups)
        {
            Console.WriteLine($"Origin: {group.Key} - Count: {group.Count()}");
            foreach (var car in group)
            {
                GetCarInfo(car);
            }
        }
    }

}