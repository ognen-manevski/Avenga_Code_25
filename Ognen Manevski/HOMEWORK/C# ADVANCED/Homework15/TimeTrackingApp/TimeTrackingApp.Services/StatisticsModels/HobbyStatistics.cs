namespace TimeTrackingApp.Services.StatisticsModels;

public class HobbyStatistics : ActivityStatistics
{
    public List<string> HobbyNames { get; set; } = new();

    public override IEnumerable<DisplayItem> GetDisplayItems()
    {
        foreach (var item in base.GetDisplayItems())
            yield return item;

        var hobbyList = HobbyNames.Any() ? string.Join(", ", HobbyNames) : "N/A";

        yield return new DisplayItem("Hobby List", hobbyList);
    }
}
