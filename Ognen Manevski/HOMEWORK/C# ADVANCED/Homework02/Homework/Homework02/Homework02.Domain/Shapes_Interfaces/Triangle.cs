using Homework02.Domain.Interfaces;

using Homework02.Domain.BaseEntity;

namespace Homework02.Domain.Models.Shapes_Interfaces;

public class Triangle : Shape, IShape
{
    public int Base { get; set; }
    public int Height { get; set; }

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
        return 0.5 * Base * Height;
    }
}
