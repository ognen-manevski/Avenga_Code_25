namespace Homework07.Library.Models;
using Homework07.Library.Enums;

public class Employee
{
    //properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Roles Role { get; set; }
    protected double Salary { get; set; } //only this class and derived classes can access this property,
                                          //but not outside of these classes.

    //constructor

    public Employee(string firstName, string lastName, Roles role, double salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Role = role;
        Salary = salary;
    }



    //methods
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {FirstName} {LastName}");
        Console.WriteLine($"Role: {Role}");
        Console.WriteLine($"Salary: {Salary}");
    }

    public virtual double GetSalary() //overridable
    {
        return Salary;
    }
}