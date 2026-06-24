using System.Diagnostics;
using TimeTrackingApp.Domain.Constants;
using TimeTrackingApp.Domain.Enums;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.App.UI.Enums;
using TimeTrackingApp.Helpers;
using TimeTrackingApp.Services.Interfaces;
using TimeTrackingApp.Services.Results;

namespace TimeTrackingApp.App.UI;

public class ActivityUI
{
    private readonly User _currentUser;
    private readonly IActivityService _activityService;

    public ActivityUI(User currentUser, IActivityService activityService)
    {
        _currentUser = currentUser;
        _activityService = activityService;
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.PrintAppName();
            ConsoleHelper.PrintHeader("TRACK ACTIVITY");

            var options = new List<string>
            {
                "Reading",
                "Exercising",
                "Working",
                "Other Hobbies",
                "Back to Main Menu"
            };

            ConsoleHelper.PrintMenu("SELECT ACTIVITY TYPE", options);
            ActivityMenuOption choice = (ActivityMenuOption)ConsoleHelper.GetMenuChoice(options.Count);

            switch (choice)
            {
                case ActivityMenuOption.Reading:
                    TrackActivity(ActivityType.Reading);
                    break;
                case ActivityMenuOption.Exercising:
                    TrackActivity(ActivityType.Exercising);
                    break;
                case ActivityMenuOption.Working:
                    TrackActivity(ActivityType.Working);
                    break;
                case ActivityMenuOption.OtherHobbies:
                    TrackActivity(ActivityType.OtherHobbies);
                    break;
                case ActivityMenuOption.BackToMainMenu:
                    return;
            }
        }
    }

    private void TrackActivity(ActivityType activityType)
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader($"TRACKING: {activityType}");

        ConsoleHelper.PrintInfo("Press ENTER to start tracking...");
        Console.ReadLine();

        var stopwatch = _activityService.StartTracking();
        ConsoleHelper.PrintSuccess("Timer started!");

        ConsoleHelper.PrintWarning("\nPress ENTER to stop tracking...");
        Console.ReadLine();

        var extraInfo = CollectExtraInfo(activityType);

        ActivityTrackingResult result = _activityService.StopTracking(_currentUser.Id, activityType, stopwatch, extraInfo);

        if (result.Success)
        {
            ConsoleHelper.PrintSuccess($"\n{result.Message}");
            ConsoleHelper.PrintInfo($"Duration: {TimeConverter.FormatTime(result.DurationInSeconds)}");
        }
        else
        {
            ConsoleHelper.PrintError($"\n{result.Message}");
        }

        ConsoleHelper.PressAnyKeyToContinue();
    }

    private Dictionary<string, string> CollectExtraInfo(ActivityType activityType)
    {
        var extraInfo = new Dictionary<string, string>();

        Console.WriteLine();
        ConsoleHelper.PrintInfo("Please provide additional information:");

        switch (activityType)
        {
            case ActivityType.Reading:
                extraInfo[ActivityExtraInfoKeys.Pages] = ConsoleHelper.GetPositiveIntInput("Number of pages read: ").ToString();

                var readingOptions = new List<string>
                {
                    "Belles Lettres",
                    "Fiction",
                    "Professional Literature"
                };

                ConsoleHelper.PrintMenu("READING TYPE", readingOptions);
                ReadingType readingType = (ReadingType)ConsoleHelper.GetMenuChoice(readingOptions.Count);
                extraInfo[ActivityExtraInfoKeys.Type] = readingType.ToString();
                break;

            case ActivityType.Exercising:
                var exerciseOptions = new List<string>
                {
                    "General",
                    "Running",
                    "Sport"
                };

                ConsoleHelper.PrintMenu("EXERCISE TYPE", exerciseOptions);
                ExerciseType exerciseType = (ExerciseType)ConsoleHelper.GetMenuChoice(exerciseOptions.Count);
                extraInfo[ActivityExtraInfoKeys.Type] = exerciseType.ToString();
                break;

            case ActivityType.Working:
                var workOptions = new List<string>
                {
                    "At the Office",
                    "From Home"
                };

                ConsoleHelper.PrintMenu("WORK LOCATION", workOptions);
                WorkLocationType workLocation = (WorkLocationType)ConsoleHelper.GetMenuChoice(workOptions.Count);
                extraInfo[ActivityExtraInfoKeys.Location] = workLocation.ToString();
                break;

            case ActivityType.OtherHobbies:
                extraInfo[ActivityExtraInfoKeys.HobbyName] = ConsoleHelper.GetStringInput("Hobby name: ");
                break;
        }

        return extraInfo;
    }
}
