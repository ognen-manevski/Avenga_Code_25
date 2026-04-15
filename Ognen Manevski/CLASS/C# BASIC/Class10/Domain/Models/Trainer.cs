
namespace AcademyManagement.Domain.Models;
using AcademyManagement.Domain.Enums;

public class Trainer : User
{

    public Trainer(string fname, string lname, string username, string password, int age)
        : base(fname, lname, username, password, age)
    {
        Role = Role.Trainer;
    }

    public Trainer(string username, string password)
        : base(username, password)
    {
        Role = Role.Trainer;
    }


}
