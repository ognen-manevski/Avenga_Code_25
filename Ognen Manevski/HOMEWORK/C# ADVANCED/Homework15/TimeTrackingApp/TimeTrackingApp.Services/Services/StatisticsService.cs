using TimeTrackingApp.DataAccess.Repositories;
using TimeTrackingApp.Domain.Constants;
using TimeTrackingApp.Domain.Enums;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Services.Interfaces;
using TimeTrackingApp.Services.StatisticsModels;
using TimeTrackingApp.Helpers;

namespace TimeTrackingApp.Services.Services;

public class StatisticsService : IStatisticsService
{
    private readonly ActivityRepository _activityRepository;

    public StatisticsService(ActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    //=======================================
    // PRIVATE HELPER METHODS
    //=======================================


    private List<ActivityRecord> GetActivitiesByType(int userId, ActivityType activityType)
    {
        return _activityRepository.GetByUserId(userId)
            .Where(a => a.ActivityType == activityType)
            .ToList();
    }

    
    private void FillCommonStats(ActivityStatistics stats, List<ActivityRecord> activities)
    {
        stats.TotalSeconds = activities.Sum(a => a.DurationInSeconds);
        stats.AverageSeconds = (int)activities.Average(a => a.DurationInSeconds); //cast as int because Average returns double
    }

    private string GetFavoriteType(List<ActivityRecord> activities, string extraInfoKey)
    {
        return activities
            .Where(a => a.ExtraInfo.ContainsKey(extraInfoKey))
            .GroupBy(a => a.ExtraInfo[extraInfoKey])
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault() ?? "N/A";
    }

    //=======================================
    // READING
    //=======================================

    public ReadingStatistics GetReadingStats(int userId)
    {
        var activities = GetActivitiesByType(userId, ActivityType.Reading);

        if (!activities.Any())
            return new ReadingStatistics
            {
                HasData = false,
                EmptyMessage = "No reading activities recorded yet."
            };

        var stats = new ReadingStatistics();
        FillCommonStats(stats, activities);

        stats.TotalPages = activities
            .Where(a => a.ExtraInfo.ContainsKey(ActivityExtraInfoKeys.Pages))
            .Sum(a => int.TryParse(a.ExtraInfo[ActivityExtraInfoKeys.Pages], out int pages) ? pages : 0);

        stats.FavoriteType = GetFavoriteType(activities, ActivityExtraInfoKeys.Type);

        return stats;
    }

    //=======================================
    // EXERCISING
    //=======================================

    public ExerciseStatistics GetExerciseStats(int userId)
    {
        var activities = GetActivitiesByType(userId, ActivityType.Exercising);

        if (!activities.Any())
            return new ExerciseStatistics
            {
                HasData = false,
                EmptyMessage = "No exercising activities recorded yet."
            };

        var stats = new ExerciseStatistics();
        FillCommonStats(stats, activities);
        stats.FavoriteType = GetFavoriteType(activities, ActivityExtraInfoKeys.Type);

        return stats;
    }

    //=======================================
    // WORKING
    //=======================================

    public WorkingStatistics GetWorkingStats(int userId)
    {
        var activities = GetActivitiesByType(userId, ActivityType.Working);

        if (!activities.Any())
            return new WorkingStatistics
            {
                HasData = false,
                EmptyMessage = "No working activities recorded yet."
            };

        var stats = new WorkingStatistics();
        FillCommonStats(stats, activities);

        stats.OfficeSeconds = activities
            .Where(a => a.ExtraInfo.ContainsKey(ActivityExtraInfoKeys.Location) && a.ExtraInfo[ActivityExtraInfoKeys.Location] == WorkLocationType.Office.ToString())
            .Sum(a => a.DurationInSeconds);

        stats.HomeSeconds = activities
            .Where(a => a.ExtraInfo.ContainsKey(ActivityExtraInfoKeys.Location) && a.ExtraInfo[ActivityExtraInfoKeys.Location] == WorkLocationType.Home.ToString())
            .Sum(a => a.DurationInSeconds);

        return stats;
    }

    //=======================================
    // HOBBY
    //=======================================

    public HobbyStatistics GetHobbyStats(int userId)
    {
        var activities = GetActivitiesByType(userId, ActivityType.OtherHobbies);

        if (!activities.Any())
            return new HobbyStatistics
            {
                HasData = false,
                EmptyMessage = "No hobby activities recorded yet."
            };

        var stats = new HobbyStatistics();
        FillCommonStats(stats, activities);

        stats.HobbyNames = activities
            .Where(a => a.ExtraInfo.ContainsKey(ActivityExtraInfoKeys.HobbyName))
            .Select(a => a.ExtraInfo[ActivityExtraInfoKeys.HobbyName])
            .Distinct()
            .ToList();

        return stats;
    }

    //=======================================
    // GLOBAL STATS
    //=======================================

    public GlobalStatistics GetGlobalStats(int userId)
    {
        var activities = _activityRepository.GetByUserId(userId);

        if (!activities.Any())
            return new GlobalStatistics
            {
                HasData = false,
                EmptyMessage = "No activities recorded yet."
            };

        var stats = new GlobalStatistics
        {
            TotalSeconds = activities.Sum(a => a.DurationInSeconds),
            FavoriteActivity = activities
                .GroupBy(a => a.ActivityType)
                .OrderByDescending(g => g.Sum(a => a.DurationInSeconds))
                .Select(g => g.Key.ToString())
                .FirstOrDefault() ?? "N/A"
        };

        foreach (ActivityType activityType in Enum.GetValues(typeof(ActivityType)))
        {
            var activitySeconds = activities
                .Where(a => a.ActivityType == activityType)
                .Sum(a => a.DurationInSeconds);

            if (activitySeconds > 0)
            {
                stats.ActivityBreakdown[activityType.ToString()] = activitySeconds;
            }
        }

        return stats;
    }
}
