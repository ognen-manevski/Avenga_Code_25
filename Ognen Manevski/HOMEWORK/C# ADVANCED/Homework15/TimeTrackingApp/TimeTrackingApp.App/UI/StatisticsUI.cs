using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Services.StatisticsModels;
using TimeTrackingApp.App.UI.Enums;
using TimeTrackingApp.Helpers;
using TimeTrackingApp.Services.Interfaces;

namespace TimeTrackingApp.App.UI;

public class StatisticsUI
{
    private readonly User _currentUser;
    private readonly IStatisticsService _statisticsService;

    public StatisticsUI(User currentUser, IStatisticsService statisticsService)
    {
        _currentUser = currentUser;
        _statisticsService = statisticsService;
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();

            ConsoleHelper.PrintAppName();
            ConsoleHelper.PrintHeader("STATISTICS");

            List<string> options = new List<string>
            {
                "Reading Statistics",
                "Exercising Statistics",
                "Working Statistics",
                "Hobbies Statistics",
                "Global Statistics",
                "Back to Main Menu"
            };

            ConsoleHelper.PrintMenu("View Statistics:", options);

            StatisticsMenuOption choice = (StatisticsMenuOption)ConsoleHelper.GetMenuChoice(options.Count);

            switch (choice)
            {
                case StatisticsMenuOption.ReadingStatistics:
                    DisplayReadingStats();
                    break;
                case StatisticsMenuOption.ExercisingStatistics:
                    DisplayExerciseStats();
                    break;
                case StatisticsMenuOption.WorkingStatistics:
                    DisplayWorkingStats();
                    break;
                case StatisticsMenuOption.HobbiesStatistics:
                    DisplayHobbyStats();
                    break;
                case StatisticsMenuOption.GlobalStatistics:
                    DisplayGlobalStats();
                    break;
                case StatisticsMenuOption.BackToMainMenu:
                    return;
            }
        }
    }



    //================================
    // Display Helpers
    //================================

    //specific ----------------------
    private void DisplayReadingStats()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("READING STATISTICS");

        var stats = _statisticsService.GetReadingStats(_currentUser.Id);
        StatisticsPrinter(stats);

        ConsoleHelper.PressAnyKeyToContinue();
    }

    private void DisplayExerciseStats()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("EXERCISING STATISTICS");

        var stats = _statisticsService.GetExerciseStats(_currentUser.Id);
        StatisticsPrinter(stats);

        ConsoleHelper.PressAnyKeyToContinue();
    }

    private void DisplayWorkingStats()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("WORKING STATISTICS");

        var stats = _statisticsService.GetWorkingStats(_currentUser.Id);
        StatisticsPrinter(stats);

        ConsoleHelper.PressAnyKeyToContinue();
    }

    private void DisplayHobbyStats()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("HOBBIES STATISTICS");

        var stats = _statisticsService.GetHobbyStats(_currentUser.Id);
        StatisticsPrinter(stats);

        ConsoleHelper.PressAnyKeyToContinue();
    }

    //global ----------------------
    private void DisplayGlobalStats()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("GLOBAL STATISTICS");

        var stats = _statisticsService.GetGlobalStats(_currentUser.Id);

        Console.WriteLine();

        if (!stats.HasData)
        {
            ConsoleHelper.PrintWarning(stats.EmptyMessage ?? "No data available.");
        }
        else
        {
            foreach (DisplayItem item in stats.GetDisplayItems())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  {item.Label}: ");
                Console.ResetColor();
                Console.WriteLine(item.Value);
            }
        }

        Console.WriteLine();
        ConsoleHelper.PressAnyKeyToContinue();
    }

    //================================

    //print helper:
    private void StatisticsPrinter(ActivityStatistics stats)
    {
        Console.WriteLine();

        if (!stats.HasData)
        {
            ConsoleHelper.PrintWarning(stats.EmptyMessage ?? "No data available.");
            return;
        }

        foreach (DisplayItem item in stats.GetDisplayItems())
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"  {item.Label}: ");
            Console.ResetColor();
            Console.WriteLine(item.Value);
        }

        Console.WriteLine();
    }
}
