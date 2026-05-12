namespace Homework02.Domain.BaseEntity
{
    public abstract class Shape 
    {

        public virtual double GetArea() { 
            return 0;
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();


        public void DisplayInfo()
        {
            Console.WriteLine($"Area: {CalculateArea()}");
            Console.WriteLine($"Perimeter: {CalculatePerimeter()}");
        }
    }
}
