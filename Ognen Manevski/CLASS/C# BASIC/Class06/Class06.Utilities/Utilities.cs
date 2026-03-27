namespace Class06.Utilities
{
    public class Utilities
    {
        //get num input
        public static double GetNumInput(string promptText)
        {
            while (true)
            {
                Console.WriteLine(promptText);
                bool isValid = double.TryParse(Console.ReadLine(), out double result);

                if (!isValid)
                {
                    Console.WriteLine("That isn't a valid number. Please try again.");
                    continue;
                }

                return result;
            }
        }

        //get text input
        //public static double GetTextInput(string promptText)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine(promptText);
        //        bool isValid = double.TryParse(Console.ReadLine(), out double result);

        //        if (!isValid)
        //        {
        //            Console.WriteLine("That isn't a valid number. Please try again.");
        //            continue;
        //        }

        //        return result;
        //    }
        //}




    }
}
