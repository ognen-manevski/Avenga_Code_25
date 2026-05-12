using Homework02.Task03_Shape_Abstract_Class.BaseEntities;


namespace Homework02.Task03_Shape_Abstract_Class.Models;

public class Circle : Shape
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
