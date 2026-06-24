
namespace TimeTrackingApp.Domain.Models;


//Register Information

//    First Name
//    Last Name
//    Age
//    Username
//    Password

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public bool IsActive { get; set; } = true;

    public User() { }
    public User(string firstName, string lastName, int age, string username, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Username = username;
        Password = password;
        IsActive = true;
    }

    public override string GetInfo()
    {
        return $"User: {FirstName} {LastName}, Age: {Age}, (Username: {Username}, Active: {IsActive})";
    }
}
