using Homework02.Domain.Interfaces;
using Homework02.Domain.BaseEntity;

namespace Homework02.Domain.Models.Shapes_Interfaces;

public class Circle : Shape, IShape
{
    public int Radius { get; set; }

    public override double CalculateArea()
    {
        throw new NotImplementedException();
    }

    public override double CalculatePerimeter()
    {
        throw new NotImplementedException();
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
