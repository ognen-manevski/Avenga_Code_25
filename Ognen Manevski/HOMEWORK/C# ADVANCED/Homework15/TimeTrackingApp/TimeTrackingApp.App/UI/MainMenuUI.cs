using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.App.UI.Enums;
using TimeTrackingApp.Helpers;
using TimeTrackingApp.Services.Interfaces;

namespace TimeTrackingApp.App.UI;

public class MainMenuUI
{
    private readonly User _currentUser;
    private readonly IActivityService _activityService;
    private readonly IStatisticsService _statisticsService;
    private readonly IAccountService _accountService;

    public MainMenuUI(
        User currentUser,
        IActivityService activityService,
        IStatisticsService statisticsService,
        IAccountService accountService)
    {
        _currentUser = currentUser;
        _activityService = activityService;
        _statisticsService = statisticsService;
        _accountService = accountService;
    }

    public bool Show()
    {
        while (true)
        {
            Console.Clear();

            ConsoleHelper.PrintAppName();
            ConsoleHelper.PrintHeader($"MAIN MENU - Welcome, {_currentUser.FirstName}!");

            var options = new List<string>
            {
                "Track Activity",
                "View Statistics",
                "Account Management",
                "Logout"
            };

            ConsoleHelper.PrintMenu("Select an Option:", options);
            MainMenuOption choice = (MainMenuOption)ConsoleHelper.GetMenuChoice(options.Count);

            switch (choice)
            {
                case MainMenuOption.TrackActivity:
                    var activityUI = new ActivityUI(_currentUser, _activityService);
                    activityUI.Show();
                    break;
                case MainMenuOption.ViewStatistics:
                    var statisticsUI = new StatisticsUI(_currentUser, _statisticsService);
                    statisticsUI.Show();
                    break;
                case MainMenuOption.AccountManagement:
                    var accountUI = new AccountManagementUI(_currentUser, _accountService);
                    bool accountActive = accountUI.Show();
                    if (!accountActive)
                    {
                        return false;
                    }
                    break;
                case MainMenuOption.Logout:
                    ConsoleHelper.PrintInfo("Logging out...");
                    ConsoleHelper.PressAnyKeyToContinue();
                    return true;
            }
        }
    }
}
