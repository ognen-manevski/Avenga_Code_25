using Homework02.Domain.BaseEntity;

namespace Homework02.Domain.Models.Shapes_Subclasses;

public class RectangleSubclass : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }
}
