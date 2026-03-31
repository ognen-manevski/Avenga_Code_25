
namespace Homework07.Library.Models;

using Homework07.Library.Enums;

public class SalesPerson : Employee
{
    //properties
    private double SuccessSaleRevenue { get; set; } = 0;

    //constructor

    //: base (firstName, lastName, role, salary)
    public SalesPerson(string firstName, string lastName)
        : base(firstName, lastName, Roles.Sales, 500)
    {

    }

    public void AddSuccessRevenue(double revenue)
    {
        //SuccessSaleRevenue = revenue; //setting revenue
        SuccessSaleRevenue += revenue; // accumulating revenue  
    }

    public override double GetSalary() //override
    {
        switch (SuccessSaleRevenue)
        {
            case <= 2000: return Salary + 500;
            case <= 5000: return Salary + 1000;
            case > 5000: return Salary + 1500;
            default: return Salary;
        }
    }
}
