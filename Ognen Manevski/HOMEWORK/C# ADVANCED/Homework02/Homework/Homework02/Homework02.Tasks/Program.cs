/*
Class 2 Homework 📒

Task #1 - Searchable

Create an interface Searchable with a method:

bool Search(string word);

The method returns true if word appears in the object's content, false otherwise (case-insensitive).

Create two classes that implement Searchable:

    Document - has a Title and a Content field (both string). Search looks inside Content.
    WebPage - has a Url and an Html field (both string). Search looks inside Html, ignoring HTML tags (a simple Regex.Replace(html, "<.*?>", "") is enough).

In Program.cs, create one Document and one WebPage, call Search on each with a word that exists and one that doesn't, and print the results.
Task #2 - Shape interface

Create an interface Shape with one method:

double GetArea();

Create three classes that implement Shape:

    Rectangle - fields Width, Height. Area = Width * Height.
    Circle - field Radius. Area = π * Radius².
    Triangle - fields Base, Height. Area = 0.5 * Base * Height.

In Program.cs, store all three in a Shape[] array and print each area in a loop.
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
Task #4 - Employee abstract class

Create an abstract class Employee with fields Name and Id, and two abstract methods:

abstract decimal CalculateSalary();
abstract void DisplayInfo();

Create two subclasses with these salary rules:

    Manager - extra fields BaseSalary and Bonus. Salary = BaseSalary + Bonus.
    Programmer - extra fields HourlyRate and HoursWorked. Salary = HourlyRate * HoursWorked.

Each subclass's DisplayInfo() should print name, id, role, and computed salary.

In Program.cs, create one Manager and one Programmer, put them in an Employee[] array, and loop through calling DisplayInfo() on each.
🤖 Using AI in Homework

You are allowed to use AI tools (ChatGPT, Copilot, Claude, etc.) while working on your homework.
🧠 How to use AI effectively

    Use AI to understand interfaces and abstract classes
    Ask for explanations, not full solutions
    Compare different approaches
    Use AI to debug your code
    Always understand what you write

⚙️ Recommended workflow

    Read the task carefully
    Identify what is:
        Interface
        Abstract class
        Concrete class
    Design your classes first
    Implement step by step
    Test your logic
    Improve your solution

❌ What to avoid

    Copy/pasting full solutions
    Mixing abstract class and interface without reason
    Writing code you don't understand
    Skipping design

💡 Key mindset

    Interface = rules
    Abstract class = shared logic
    Class = implementation

*/

using Homework02.Domain.BaseEntity;
using Homework02.Domain.Models.Shapes_Subclasses;
using Homework02.Domain.Models.Employees;
using Homework02.Domain.Models.Shapes_Interfaces;
using Homework02.Domain.Models.Websites;




//Task #3 - Shape abstract class

RectangleSubclass rectangleS = new RectangleSubclass { Width = 5, Height = 10 };
rectangleS.DisplayInfo();

CircleSubclass circleS = new CircleSubclass { Radius = 5 };
circleS.DisplayInfo();

TriangleSubclass triangleS = new TriangleSubclass { SideA = 3, SideB = 4, SideC = 5 };
triangleS.DisplayInfo();


//Task #4 - Employee abstract class     

Manager managerAlice = new Manager(1, "Alice", 50000, 10000);
Programmer programmerBob = new Programmer(2, "Bob", 50, 160);

Array employees = new Employee[] { managerAlice, programmerBob };

foreach (Employee e in employees)
{
    e.DisplayInfo();
}