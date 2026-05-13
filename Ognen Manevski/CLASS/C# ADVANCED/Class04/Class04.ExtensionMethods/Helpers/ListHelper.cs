namespace Class04.ExtensionMethods.Helpers;

public static class ListHelper
{
    public static void PrintItems<T>(this List<T> items) //this is an extension method for List<T>
    {
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }
}
