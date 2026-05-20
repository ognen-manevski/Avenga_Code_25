namespace Homework04.Task01;

public static class PrintInConsole
{
    public static void Print<T>(T value)
    {
        Console.WriteLine($"Printing value of type {typeof(T).Name}: {value}");
    }

    public static void PrintCollection<T>(IEnumerable<T> collection)
    {
        Console.WriteLine($"Printing collection of type {typeof(T).Name}:");
        foreach (T item in collection)
        {
            Console.WriteLine(item);
        }
    }
}
