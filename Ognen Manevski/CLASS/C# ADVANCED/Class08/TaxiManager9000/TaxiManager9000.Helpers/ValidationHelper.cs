namespace TaxiManager9000.Helpers;

public static class ValidationHelper
{
    public static int ValidateNumberInput(string inputNumber, int range)
    {
        bool isValidInt = int.TryParse(inputNumber, out int value);

        if (value >= 1 && value <= range)
        {
            return value;
        }

        return -1; // Return -1 to indicate invalid input
    }
}
