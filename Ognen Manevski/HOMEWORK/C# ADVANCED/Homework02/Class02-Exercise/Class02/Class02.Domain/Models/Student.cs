using Class02.Domain.Base_Entity;
using Class02.Domain.Interfaces;

namespace Class02.Domain.Models
{
    public class Student : User, IStudent
    {
        public List<string> Grades { get; set; }

        public override void PrintUser()
        {
            string grades = string.Join(", ", Grades);

            Console.WriteLine($"| Id: {Id,3} | Name: {Name,-20} | Grades: {grades, -20} |");
        }
    }
}
