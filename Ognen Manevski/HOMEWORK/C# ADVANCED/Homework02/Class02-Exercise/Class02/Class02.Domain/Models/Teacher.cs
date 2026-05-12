using Class02.Domain.Base_Entity;
using Class02.Domain.Interfaces;

namespace Class02.Domain.Models
{
    public class Teacher : User, ITeacher
    {
        public string Subject { get; set; }

        public override void PrintUser()
        {
            Console.WriteLine($"| Id: {Id,3} | Name: {Name,-20} | Subject: {Subject, -20} |");
        }
    }
}
