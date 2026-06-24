namespace TimeTrackingApp.Services.StatisticsModels;

public class DisplayItem
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    public DisplayItem() { }

    public DisplayItem(string label, string value)
    {
        Label = label;
        Value = value;
    }
}
