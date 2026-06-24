using System.Diagnostics;
using TimeTrackingApp.DataAccess.Repositories;
using TimeTrackingApp.Domain.Enums;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Services.Interfaces;
using TimeTrackingApp.Helpers;
using TimeTrackingApp.Services.Results;

namespace TimeTrackingApp.Services.Services;

public class ActivityService : IActivityService
{
    private readonly ActivityRepository _activityRepository;

    public ActivityService(ActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    //Using Stopwatch to track time -> System.Diagnostics;
    //can return a timespan object or miliseconds long
    public Stopwatch StartTracking()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        return stopwatch;
    }

    public ActivityTrackingResult StopTracking
        (
            int userId,
            ActivityType activityType,
            Stopwatch stopwatch,
            Dictionary<string, string> extraInfo
        )
    {
        try
        {
            stopwatch.Stop();

            //cast as int since it returns a double - I only need whole seconds
            int durationInSeconds = (int)stopwatch.Elapsed.TotalSeconds;

            ActivityRecord? activityRecord = new ActivityRecord
            {
                UserId = userId,
                ActivityType = activityType,
                DurationInSeconds = durationInSeconds,
                ExtraInfo = extraInfo
            };

            _activityRepository.Add(activityRecord);

            return new ActivityTrackingResult(true, $"Activity tracked successfully! [{TimeConverter.FormatTime(durationInSeconds)}]", durationInSeconds);
        }
        catch (Exception ex)
        {
            return new ActivityTrackingResult(false, $"Error tracking activity: {ex.Message}", 0);
        }
    }

    //public List<ActivityRecord> GetUserActivities(int userId)
    //{
    //    return _activityRepository.GetByUserId(userId);
    //}
}
