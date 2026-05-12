namespace Homework02.Domain.BaseEntity
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract decimal CalculateSalary();
        public abstract void DisplayInfo();
    }
}
