using Homework02.Domain.BaseEntity;

namespace Homework02.Domain.Models.Shapes_Subclasses;

public class TriangleSubclass : Shape
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
