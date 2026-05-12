using Homework02.Task02_ShapeInterface.Interfaces;

namespace Homework02.Task02_ShapeInterface.Models;

public class Triangle : IShape
{
    public int Base { get; set; }
    public int Height { get; set; }


    public double GetArea()
    {
        return 0.5 * Base * Height;
    }
}
