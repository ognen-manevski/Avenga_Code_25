namespace TimeTrackingApp.Domain.Models;

using TimeTrackingApp.Domain.Enums;

public class ActivityRecord : BaseEntity
{
    public int UserId { get; set; }
    public ActivityType ActivityType { get; set; }

    //stored in seconds
    public int DurationInSeconds { get; set; }
    public Dictionary<string, string> ExtraInfo { get; set; } = new Dictionary<string, string>();

    public ActivityRecord() { }
    public ActivityRecord(int userId, ActivityType activityType, int durationInSeconds)
    {
        UserId = userId;
        ActivityType = activityType;
        DurationInSeconds = durationInSeconds;
        ExtraInfo = new Dictionary<string, string>();
    }

    public override string GetInfo()
    {
        return $"Activity: {ActivityType} - Duration: {DurationInSeconds} seconds.";
    }
}
