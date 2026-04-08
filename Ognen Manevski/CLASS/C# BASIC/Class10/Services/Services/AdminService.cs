namespace AcademyManagement.Services.Services;

using AcademyManagement.Domain;
using AcademyManagement.Domain.Models;
using AcademyManagement.Domain.Enums;

public class AdminService
{

    private DataAccess _dataAccess;

    public AdminService()
    {
        _dataAccess = new DataAccess();
    }


    //Login

    public Admin AdminLogin(string username, string password)
    {
        Admin? adminFromDb = _dataAccess.GetAdmin(username, password);

        if (adminFromDb == null)
        {
            throw new Exception("Invalid username or password.");
        }

        return adminFromDb;
    }


    //Create User

    public void CreateUser(string firstName, string lastName, string username, string password, string age, Role role)
    {
        bool userExists = _dataAccess.CheckIfUserExists(username, role);
        if (userExists)

        {
            throw new Exception($@" {role.ToString()} with {username} Already Exists");
        }

        _dataAccess.CreateNewUser(firstName, lastName, username, password, age, role);
    }



    //Delete User

    public void DeleteUser(string username, Role role)
    {
        bool userExists = _dataAccess.CheckIfUserExists(username, role);
        if (!userExists)
        {
            throw new Exception("Cannot delete user that doesn't exist!");
        }
        _dataAccess.DeleteUser(username, role);
    }


    //GetUsersToRemove

    public List<string> GetUsersToRemove(Role role, Admin LoggedAdmin)
    {
        return _dataAccess.GetUserNames(role, LoggedAdmin);
    }



}
