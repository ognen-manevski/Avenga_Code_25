using TimeTrackingApp.Helpers;

namespace TimeTrackingApp.Services.StatisticsModels;

public abstract class ActivityStatistics
{
    public bool HasData { get; set; } = true;
    public string? EmptyMessage { get; set; }

    public int TotalSeconds { get; set; }
    public int AverageSeconds { get; set; }

    public virtual IEnumerable<DisplayItem> GetDisplayItems()
    {
        if (!HasData)
            yield break;

        yield return new DisplayItem("Total Time", TimeConverter.FormatTime(TotalSeconds));
        yield return new DisplayItem("Average Time", TimeConverter.FormatTime(AverageSeconds));
    }
}
