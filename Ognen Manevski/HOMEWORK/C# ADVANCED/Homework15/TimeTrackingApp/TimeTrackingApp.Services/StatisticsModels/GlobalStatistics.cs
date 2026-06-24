namespace TimeTrackingApp.Services.StatisticsModels;

using TimeTrackingApp.Helpers;

public class GlobalStatistics
{
    public bool HasData { get; set; } = true;
    public string? EmptyMessage { get; set; }
    public int TotalSeconds { get; set; }
    public string FavoriteActivity { get; set; } = "N/A";
    public Dictionary<string, int> ActivityBreakdown { get; set; } = new();

    public IEnumerable<DisplayItem> GetDisplayItems()
    {
        if (!HasData)
            yield break;

        yield return new DisplayItem("Total Time (All Activities)", TimeConverter.FormatTime(TotalSeconds));
        yield return new DisplayItem("Favorite Activity", FavoriteActivity);

        foreach (var (activity, seconds) in ActivityBreakdown.OrderByDescending(x => x.Value))
        {
            yield return new DisplayItem($"{activity} Time", TimeConverter.FormatTime(seconds));
        }
    }
}
