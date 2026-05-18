namespace Class04.ExtensionMethods.Helpers;

public static class ListHelper
{
    public static void PrintItems<T>(this List<T> items) //"this" is an extension method for List<T>
                                                         //extending the List<T> class with a new method called PrintItems
                                                         //that takes a List<T> as a parameter and prints each item in the list to the console
                                                         //!the class and method MUST be static!
                                                         //now every list of any type can call PrintItems()
                                                         //why is it in parenthesis like this? because it's an extension method, it needs to be called on an instance of List<T>, so the first parameter is the instance itself, and the "this" keyword indicates that it's an extension method for that type
    {
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }

    public static void PrintListInfo<T>(this List<T> items)
    {
        string listType = typeof(T).Name;
        Console.WriteLine($"This list has {items.Count} elements of type {listType}.");
    }

}
