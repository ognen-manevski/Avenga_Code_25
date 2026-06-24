namespace TimeTrackingApp.Services.StatisticsModels;

using TimeTrackingApp.Helpers;
public class WorkingStatistics : ActivityStatistics
{
    public int OfficeSeconds { get; set; }
    public int HomeSeconds { get; set; }

    public override IEnumerable<DisplayItem> GetDisplayItems()
    {
        foreach (var item in base.GetDisplayItems())
            yield return item;

        yield return new DisplayItem("Office Time", TimeConverter.FormatTime(OfficeSeconds));
        yield return new DisplayItem("Home Time", TimeConverter.FormatTime(HomeSeconds));
    }
}
