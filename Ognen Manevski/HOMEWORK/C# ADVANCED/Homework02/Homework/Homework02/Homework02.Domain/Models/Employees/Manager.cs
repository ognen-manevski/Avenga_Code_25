using Homework02.Domain.BaseEntity;

namespace Homework02.Domain.Models.Employees
{
    public class Manager : Employee
    {
        public int BaseSalary { get; set; }
        public int Bonus { get; set; }


        //ctor
        public Manager(int id, string name, int baseSalary, int bonus)
            : base(id, name)
        {
            BaseSalary = baseSalary;
            Bonus = bonus;
        }

        public override decimal CalculateSalary()
        {
            return BaseSalary + Bonus;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"| {Id,3} | {Name,-10} | {CalculateSalary(),-10} |");
        }
    }
}
