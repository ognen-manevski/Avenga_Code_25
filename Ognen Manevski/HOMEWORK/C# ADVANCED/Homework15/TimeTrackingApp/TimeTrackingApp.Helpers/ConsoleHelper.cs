using TimeTrackingApp.Helpers.Results;

namespace TimeTrackingApp.Helpers;

public static class ConsoleHelper
{

    private const int _w = 62; //TOTAL MENU WIDTH ref

    public static void PrintInColor(string value, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(value);
        Console.ResetColor();
    }

    public static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }


    public static void PrintMenu(string title, List<string> options)
    {
        List<string> menuLines = new List<string>();

        for (int i = 0; i < options.Count; i++)
        {
            menuLines.Add($"[{i + 1}] {options[i]}");
        }

        PrintBox(title, menuLines);
    }

    public static int GetMenuChoice(int optionsCount)
    {
        while (true)
        {
            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();

            //input ?? "" -> if input is null -> pass an empty string ""; 1 to optionsCount - menu range
            ValidationResult validationResult = ValidationHelper.ValidateMenuInput(input ?? "", 1, optionsCount);

            if (validationResult.IsValid && int.TryParse(input, out int choice))
            {
                return choice;
            }

            PrintError(validationResult.ErrorMessage);
        }
    }


    public static void PressAnyKeyToContinue(string msg = "Press any key to continue...")
    {
        Console.WriteLine();
        PrintInfo(msg);
        Console.ReadKey(true);
    }

    //============================
    // HEADERS
    //============================

    public static void PrintHeader(string text, ConsoleColor color = ConsoleColor.White)
    {
        //preview:
        //+--------------------------------------------------+
        //|                    Menu Title Here               |
        //+--------------------------------------------------+


        int t = text.Length; //text length
        int diff = _w - t; // width - text length

        // pre-calculating padding
        int padStart = diff / 2;
        int padEnd = diff - padStart;

        //+--------------------------------------------------+
        string border = $"+{new string('-', _w)}+";

        //centered title
        string titleRow = $"|{new string(' ', padStart)}{text}{new string(' ', padEnd)}|";

        //final title with border
        string titleFormatted = $"{border}\n{titleRow}\n{border}";

        PrintInColor(titleFormatted, color);
        Console.WriteLine();
    }

    public static void PrintBox(string title, List<string> lines)
    {
        //title
        Console.WriteLine($"+{new string('-', _w)}+");
        Console.WriteLine($"| {title.PadRight(_w - 2)} |");
        Console.WriteLine($"+{new string('-', _w)}+");


        //body
        foreach (var line in lines)
        {
            Console.WriteLine($"| {line.PadRight(_w - 2)} |");
        }

        Console.WriteLine($"+{new string('-', _w)}+");
        Console.WriteLine();
    }


    public static void PrintAppName()
    {
        string title = @"
  _______ _             _______             _    _             
 |__   __(_)           |__   __|           | |  (_)            
    | |   _ _ __ ___   ___| |_ __ __ _  ___| | ___ _ __   __ _ 
    | |  | | '_ ` _ \ / _ \ | '__/ _` |/ __| |/ / | '_ \ / _` |
    | |  | | | | | | |  __/ | | | (_| | (__|   <| | | | | (_| |
    |_|  |_|_| |_| |_|\___|_|_|  \__,_|\___|_|\_\_|_| |_|\__, |
                                                          __/ |
    [   A   P   P   L   I   C   A   T   I   O   N   ]    |___/ ";


        List<ConsoleColor> colors = new List<ConsoleColor>
        {
            ConsoleColor.Red,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkYellow,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.Cyan,
            ConsoleColor.Blue,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkMagenta,
            ConsoleColor.Magenta
        };

        Random random = new Random();
        int i = random.Next(colors.Count);

        string[] lines = title.Split('\n');

        int counter = 0;

        foreach (string line in lines)
        {
            Console.ForegroundColor = colors[i];
            Console.WriteLine(line);

            if (counter > 1)
            {
                i = (i + 1) % colors.Count; //loop back
            }
            counter++;
        }

        Console.ResetColor();
        Console.WriteLine();
    }





    //============================
    // INPUT + VALIDATION
    //============================

    public static string GetStringInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            PrintError("Input cannot be empty. Please try again.");
        }
    }

    public static string GetValidatedStringInput(string prompt, Func<string, ValidationResult> validator)
    {
        while (true)
        {
            string input = GetStringInput(prompt);
            ValidationResult validationResult = validator(input);

            if (validationResult.IsValid)
            {
                return input;
            }

            PrintError(validationResult.ErrorMessage);
        }
    }

    public static int GetIntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                return result;
            }

            PrintError("Please enter a valid number.");
        }
    }

    public static int GetValidatedIntInput(string prompt, Func<int, ValidationResult> validator)
    {
        while (true)
        {
            int input = GetIntInput(prompt);
            ValidationResult validationResult = validator(input);

            if (validationResult.IsValid)
            {
                return input;
            }

            PrintError(validationResult.ErrorMessage);
        }
    }

    public static int GetPositiveIntInput(string prompt)
    {
        return GetValidatedIntInput(prompt, value =>
            value > 0
                ? new ValidationResult(true, string.Empty)
                : new ValidationResult(false, "Please enter a number greater than zero."));
    }

    public static string GetPasswordInput(string prompt)
    {
        Console.Write(prompt);
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        }
        while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }

    public static string GetValidatedPasswordInput(string prompt, Func<string, ValidationResult> validator)
    {
        while (true)
        {
            string password = GetPasswordInput(prompt);
            ValidationResult validationResult = validator(password);

            if (validationResult.IsValid)
            {
                return password;
            }

            PrintError(validationResult.ErrorMessage);
        }
    }

    public static bool GetConfirmation(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? response = Console.ReadLine()?.Trim().ToLower();

            if (response is "y" or "yes")
            {
                return true;
            }

            if (response is "n" or "no")
            {
                return false;
            }

            PrintError("Please enter y/yes or n/no.");
        }
    }
}
