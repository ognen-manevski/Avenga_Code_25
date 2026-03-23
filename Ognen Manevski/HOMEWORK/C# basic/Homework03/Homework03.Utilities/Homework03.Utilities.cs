namespace Homework03.Utilities
{
    public static class Utilities
    {
        public static int GetNumInput(string promptText)
        {
            while (true)
            {
                Console.WriteLine(promptText);
                bool isValid = int.TryParse(Console.ReadLine(), out int result);

                if (!isValid)
                {
                    PrintError("That isn't a valid number. Please try again.");
                    continue;
                }

                return result;
            }
        }

        public static void PrintError(string err)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(err);
            Console.ResetColor();
        }

        public static void HighlightColor(string txt)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(txt);
            Console.ResetColor();
        }

    }

}

