namespace Homework04.Task02.Models;

using Homework04.Task02.Models.BaseEntity;

public class Plane : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"I'm a plane i have couple of wheels :)");
    }
}
