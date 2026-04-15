
namespace AcademyManagement.Domain.Models;
using AcademyManagement.Domain.Enums;

public class Admin : User
{
    public Admin(string fname, string lname, string username, string password, int age)
    : base(fname, lname, username, password, age)
    {
        Role = Role.Admin;
    }

    public Admin(string username, string password)
    : base(username, password) 
    {
        Role = Role.Admin;
    }
}
