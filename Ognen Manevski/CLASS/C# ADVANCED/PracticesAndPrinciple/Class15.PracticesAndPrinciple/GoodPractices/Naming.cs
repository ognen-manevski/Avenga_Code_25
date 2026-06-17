namespace Class15.PracticesAndPrinciple.GoodPractices;


#region CLASSES, PROPERTIES, FIELDS, METHODS, PARAMETERS, etc.

//BAD EXAMPLE:
//

//GOOD EXAMPLE:

internal class User
{
    private readonly string _usersFolder = @"C:\Users";

    public int Age { get; set; }
    public bool IsLoggedIn { get; set; }
    public List<string> Hobbies { get; set; } = new List<string>();
    public string UserName { get; set; }
    public string Password { get; set; }

    public User()
    {

    }


    public void ChangeUsername(string username)
    {
        UserName = username;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }

    //public async void AsyncGetUsers()
    //{
    //    //
    //}

    public async Task AsyncGetUsers()
    {
        //
    }
}

#endregion


#region Enums

public enum Roles
{
    Admin = 1,
    User,
    Manager
}

#endregion

#region Interfaces

public interface IUserService
{
    //
}

#endregion


public class Naming
{
}
}
