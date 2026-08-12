namespace Homework02.UsersApi.Models;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName  => $"{FirstName} {LastName}";


    public User(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

}
