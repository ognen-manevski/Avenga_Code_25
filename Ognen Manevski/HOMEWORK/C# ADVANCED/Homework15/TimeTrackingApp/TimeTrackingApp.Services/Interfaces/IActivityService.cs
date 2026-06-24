using System.Diagnostics;
using TimeTrackingApp.Domain.Enums;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Services.Results;

namespace TimeTrackingApp.Services.Interfaces;

public interface IActivityService
{
    Stopwatch StartTracking();
    ActivityTrackingResult StopTracking(int userId, ActivityType activityType, Stopwatch stopwatch, Dictionary<string, string> extraInfo);
    //List<ActivityRecord> GetUserActivities(int userId);
}
