using Homework02.Task02_ShapeInterface.Interfaces;

namespace Homework02.Task02_ShapeInterface.Models;


public class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public double GetArea()
    {
        return Width * Height;
    }

}
