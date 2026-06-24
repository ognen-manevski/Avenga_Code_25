namespace TimeTrackingApp.Services.Results;

public class ActivityTrackingResult : ServiceResult
{
    public int DurationInSeconds { get; set; }

    public ActivityTrackingResult() { }

    public ActivityTrackingResult(bool success, string message, int durationInSeconds)
        : base(success, message)
    {
        DurationInSeconds = durationInSeconds;
    }
}
