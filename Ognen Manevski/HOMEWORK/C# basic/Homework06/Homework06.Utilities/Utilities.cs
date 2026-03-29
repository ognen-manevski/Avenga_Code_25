namespace Homework06.Utilities
{
    public class Utilities
    {

        //get num input
        public static double GetNumInput(string promptText, bool oneLine = false)
        {
            while (true)
            {
                if(oneLine) Console.Write(promptText);
                else Console.WriteLine(promptText);

                bool isValid = double.TryParse(Console.ReadLine().TrimStart().TrimEnd(), out double result);

                if (!isValid)
                {
                    Console.WriteLine("That isn't a valid number. Please try again.");
                    continue;
                }

                return result;
            }
        }

    }
}