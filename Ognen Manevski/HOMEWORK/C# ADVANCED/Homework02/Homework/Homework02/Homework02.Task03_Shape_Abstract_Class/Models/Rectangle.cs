using Homework02.Task03_Shape_Abstract_Class.BaseEntities;

namespace Homework02.Task03_Shape_Abstract_Class.Models;

public class Rectangle : Shape
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
