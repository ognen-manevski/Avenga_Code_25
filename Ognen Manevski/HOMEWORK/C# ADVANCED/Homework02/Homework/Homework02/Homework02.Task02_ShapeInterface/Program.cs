/*
Task #2 - Shape interface

Create an interface Shape with one method:

double GetArea();

Create three classes that implement Shape:

    Rectangle - fields Width, Height. Area = Width * Height.
    Circle - field Radius. Area = π * Radius².
    Triangle - fields Base, Height. Area = 0.5 * Base * Height.

In Program.cs, store all three in a Shape[] array and print each area in a loop. 
*/

//Task #2 - Shape interface

using Homework02.Task02_ShapeInterface.Models;
using Homework02.Task02_ShapeInterface.Interfaces;

Rectangle rectangle = new Rectangle { Width = 50, Height = 100 };
Circle circle = new Circle { Radius = 32 };
Triangle triangle = new Triangle { Base = 2, Height = 20 };

Array shapes = new IShape[] { rectangle, circle, triangle };

foreach (IShape s in shapes)
{
    Console.WriteLine($"Area: {s.GetArea()}");
}
