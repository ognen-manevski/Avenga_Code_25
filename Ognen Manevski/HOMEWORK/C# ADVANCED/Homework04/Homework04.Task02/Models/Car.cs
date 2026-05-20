namespace Homework04.Task02.Models;
using Homework04.Task02.Models.BaseEntity;

public class Car : Vehicle
{
    public string NumberOfWheels { get; set; } = "4";

    public override void DisplayInfo()
    {
        Console.WriteLine($"Im a car and i drive on {NumberOfWheels} wheels :)");
    }
}
