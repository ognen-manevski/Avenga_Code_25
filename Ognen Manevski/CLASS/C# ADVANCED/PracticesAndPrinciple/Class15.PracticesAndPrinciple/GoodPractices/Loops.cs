namespace Class15.PracticesAndPrinciple.GoodPractices;

internal class Loops
{
    public List<string> Names = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve" };

    public void PrintNames()
    {
        //BAD EXAMPLE:
        for (int i = 0; i < Names.Count; i++)
        {
            if (Names[i].Length == Names.Count)
            {
                Console.WriteLine(Names[i]);
            }
        }

        //GOOD EXAMPLE:
        int namesCount = Names.Count; // Store the count in a variable to avoid multiple calls to Count property

        foreach (string name in Names)
        {
            if (name.Length == namesCount)
            {
                Console.WriteLine(name);
            }
        }
    }

    public void PrintAlice()
    {
        foreach (string name in Names)
        {
            if (name == "Alice")
            {
                Console.WriteLine(name);
                break; // Exit the loop once "Alice" is found to avoid unnecessary iterations
            }
        }
    }










}
