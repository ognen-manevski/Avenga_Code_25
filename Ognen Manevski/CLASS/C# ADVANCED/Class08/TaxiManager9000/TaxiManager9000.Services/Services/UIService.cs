using TaxiManager9000.Helpers;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services;

public class UIService : IUIService
{
    public int ChooseMenu<T>(List<T> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {items[i]}");
        }

        int choice = ValidationHelper.ValidateNumberInput(Console.ReadLine(), items.Count);

        return choice;
    }

}
