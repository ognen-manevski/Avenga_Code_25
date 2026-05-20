namespace Homework04.Task02.Models;
using Homework04.Task02.Models.BaseEntity;

public class MotorBike : Vehicle
{
    public string NumberOfWheels { get; set; } = "2";

    public override void DisplayInfo()
    {
        Console.WriteLine($"Im a motorbike and i drive on {NumberOfWheels} wheels :)");
    }
}
