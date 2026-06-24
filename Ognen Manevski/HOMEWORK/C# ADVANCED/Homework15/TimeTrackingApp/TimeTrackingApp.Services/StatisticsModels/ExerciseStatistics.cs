namespace TimeTrackingApp.Services.StatisticsModels;

public class ExerciseStatistics : ActivityStatistics
{
    public string FavoriteType { get; set; } = "N/A";

    public override IEnumerable<DisplayItem> GetDisplayItems()
    {
        foreach (var item in base.GetDisplayItems())
            yield return item;

        yield return new DisplayItem("Favorite Type", FavoriteType);
    }
}
