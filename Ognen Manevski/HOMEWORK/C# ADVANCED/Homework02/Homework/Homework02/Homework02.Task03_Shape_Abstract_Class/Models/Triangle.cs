using Homework02.Task03_Shape_Abstract_Class.BaseEntities;

namespace Homework02.Task03_Shape_Abstract_Class.Models;

public class Triangle : Shape
{
    public int SideA{ get; set; }
    public int SideB { get; set; }
    public int SideC { get; set; }

    public override double CalculateArea()
    {
        double s = (SideA + SideB + SideC) / 2.0;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }
    public override double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }


}
