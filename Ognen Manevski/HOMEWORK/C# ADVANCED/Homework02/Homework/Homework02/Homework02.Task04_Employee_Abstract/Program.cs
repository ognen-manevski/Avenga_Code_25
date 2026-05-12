/*
Task #4 - Employee abstract class

Create an abstract class Employee with fields Name and Id, and two abstract methods:

abstract decimal CalculateSalary();
abstract void DisplayInfo();

Create two subclasses with these salary rules:

    Manager - extra fields BaseSalary and Bonus. Salary = BaseSalary + Bonus.
    Programmer - extra fields HourlyRate and HoursWorked. Salary = HourlyRate * HoursWorked.

Each subclass's DisplayInfo() should print name, id, role, and computed salary.

In Program.cs, create one Manager and one Programmer, put them in an Employee[] array, and loop through calling DisplayInfo() on each.
*/

//Task #4 - Employee abstract class     

using Homework02.Task04_Employee_Abstract.BaseEntities;
using Homework02.Task04_Employee_Abstract.Models;

Manager managerAlice = new Manager(1, "Alice", 50000, 10000);
Programmer programmerBob = new Programmer(2, "Bob", 50, 160);

Array employees = new Employee[] { managerAlice, programmerBob };

foreach (Employee e in employees)
{
    e.DisplayInfo();
}