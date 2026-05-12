using Homework02.Task02_ShapeInterface.Interfaces;

namespace Homework02.Task02_ShapeInterface.Models;

public class Circle : IShape
{
    public int Radius { get; set; }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
