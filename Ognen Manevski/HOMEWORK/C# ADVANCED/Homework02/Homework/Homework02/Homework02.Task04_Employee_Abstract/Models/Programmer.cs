using Homework02.Task04_Employee_Abstract.BaseEntities;

namespace Homework02.Task04_Employee_Abstract.Models;

public class Programmer : Employee
{
    public int HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    //ctor
    public Programmer(int id, string name, int hourlyRate, int hoursWorked)
        : base(id, name)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"| {Id,3} | {Name,-10} | Programmer | {CalculateSalary(),-10} |");
    }
}

