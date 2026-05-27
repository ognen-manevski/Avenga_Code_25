using TaxiManager9000.Helpers;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.App;

internal class TaxiManagerUI
{

    private readonly IUIService _uiService;

    public void InitApp()
    {
        while (true)
        {

            #region Login Menu

            try
            {
                ConsoleHelper.PrintTitle("\n\tWelcome to Taxi Manager 9000!\n");

                //int choice = _uiService.ChooseMenu(new List<string> { "Login", "Register", "Exit" });
                int choice = _uiService.ChooseMenu(["Login", "Exit"]);


                if (choice == -1)
                {
                    ConsoleHelper.PrintError("Invalid choice. Please try again.");
                    continue;
                }
                if (choice == 2)
                {
                    break;
                }

                //login menu


            }
            catch (Exception ex)
            {
                ConsoleHelper.PrintError($"An error occurred: {ex.Message}");
                continue;
            }

            #endregion

        }
    }
}
