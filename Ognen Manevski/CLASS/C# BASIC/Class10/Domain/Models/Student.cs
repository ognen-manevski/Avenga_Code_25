
namespace AcademyManagement.Domain.Models;
using AcademyManagement.Domain.Enums;

public class Student : User
{
    public string CurrentSubject { get; set; }
    public Dictionary<string, int> Grades { get; set; } = new Dictionary<string, int>();

    public Student( string username, string password)
        : base(username, password)  
    {
        Role = Role.Student;
    }

    public Student(string fname, string lname, string username, string password, int age)
        : base(fname, lname, username, password, age)
    {
        Role = Role.Student;
    }



}
