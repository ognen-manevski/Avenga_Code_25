namespace Class04.Generics.Helpers;

public class NonGenericListHelper
{
    public void PrintStrings(List<string> strings)
    {
        Console.WriteLine("========== Print Strings ==========");
        foreach (var item in strings)
        {
            Console.WriteLine(item);
        }
    }

    public void PrintInts(List<int> ints)
    {
        Console.WriteLine("========== Print Ints ==========");
        foreach (var item in ints)
        {
            Console.WriteLine(item);
        }
    }

     public void PrintBools(List<bool> bools)
    {
        Console.WriteLine("========== Print Bools ==========");
        foreach (var item in bools)
        {
            Console.WriteLine(item);
        }
    }

    //

    public void PrintInfoForStrings(List<string> strings)
    {
        string first = strings[0];
        string elementType = first.GetType().Name;

        Console.WriteLine($"This list has {strings.Count} elements and is of type {elementType}");
    }

    public void PrintInfoForIntegers(List<int> integers )
    {
        int first = integers[0];
        string elementType = first.GetType().Name;

        Console.WriteLine($"This list has {integers.Count} elements and is of type {elementType}");
    }

    public void PrintInfoForBools(List<bool> bools)
    {
        bool first = bools[0];
        string elementType = first.GetType().Name;

        Console.WriteLine($"This list has {bools.Count} elements and is of type {elementType}");
    }


}
