using Homework03.name.BaseEntities;

namespace Homework03.name.Classes;

public class Boat : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine("I'm a boat and i do not have wheels :(");
    }
}
