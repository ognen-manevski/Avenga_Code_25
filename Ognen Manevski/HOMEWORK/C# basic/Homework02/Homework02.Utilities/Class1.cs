namespace Homework02.Utilities;

public static class Utilities
{

    // get and validate user numeric input
    // short? means the method can accept a double value or null (if no min/max is provided)
    public static double GetNumInput(string promptText, double? min = null, double? max = null)
    {
        while (true) // loop until return
        {
            Console.WriteLine(promptText);
            bool isValid = double.TryParse(Console.ReadLine(), out double result);

            if (!isValid)
            {
                PrintError("That isn't a valid number. Please try again.");
                continue; //restart loop
            }

            // if minmax values are provided:
            if (
                (min != null && result < min) ||
                (max != null && result > max)
                )
            {
                PrintError($"Please enter a number between {min} and {max}");
                continue;
            }

            return result;
        }
    }

    //change error color to red
    public static void PrintError(string err)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(err);
        Console.ResetColor();
    }

    //change highlight color to cyan
    public static void HighlightColor(string txt)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(txt);
        Console.ResetColor();
    }

}