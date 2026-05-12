/*
Task #3 - Shape abstract class

    This task contrasts with Task 2. There you used an interface (a contract only). Here you use an abstract class so subclasses can share state and helper logic.

Create an abstract class Shape with two abstract methods:

abstract double CalculateArea();
abstract double CalculatePerimeter();

Create three subclasses:

    Rectangle - fields Width, Height.
    Circle - field Radius.
    Triangle - fields SideA, SideB, SideC (use Heron's formula for area).

Add a non-abstract method DisplayInfo() in the base Shape class that prints the shape's area and perimeter - this shows why an abstract class is useful (shared behavior across subclasses).

In Program.cs, create one of each and call DisplayInfo() on them.
*/


//Task #3 - Shape abstract class
namespace Homework02.Task04_Employee_Abstract.Models;

Rectangle rectangle = new Rectangle { Width = 5, Height = 10 };
rectangle.DisplayInfo();

Circle circle = new Circle { Radius = 5 };
circle.DisplayInfo();

Triangle triangle = new Triangle { SideA = 3, SideB = 4, SideC = 5 };
triangle.DisplayInfo();