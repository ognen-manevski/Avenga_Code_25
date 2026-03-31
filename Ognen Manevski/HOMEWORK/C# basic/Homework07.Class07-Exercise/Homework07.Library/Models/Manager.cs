namespace Homework07.Library.Models;

using Homework07.Library.Enums;

public class Manager : Employee
{
    private double Bonus { get; set; } = 0;


    //: base (firstName, lastName, role, salary)
    public Manager(string firstName, string lastName, double salary)
        : base(firstName, lastName, Roles.Manager, salary)
    {

    }

    public void AddBonus(double bonus)
    {
        //Bonus = bonus;
        Bonus += bonus;
    }

    public override double GetSalary() //override
    {
        return Salary + Bonus;
    }

}
