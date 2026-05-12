using Homework02.Task02_ShapeInterface.Interfaces;


namespace Homework02.Domain.Models.Shapes_Subclasses;

public class CircleSubclass : IShape
{
    public int Radius { get; set; }


    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}
