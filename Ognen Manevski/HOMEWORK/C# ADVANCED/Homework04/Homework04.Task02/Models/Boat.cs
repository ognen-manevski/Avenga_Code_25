namespace Homework04.Task02.Models;

using Homework04.Task02.Models.BaseEntity;

public class Boat : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"I'm a boat and i do not have wheels :(");
    }
}
