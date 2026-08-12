
using Homework02.UsersApi.Models;

namespace Homework02.UsersApi;

public static class staticDb
{

    public static List<User> UsersDb { get; set; } = new List<User>()
    {
        new User(1, "John", "Doe"),
        new User(2, "Jane", "Smith"),
        new User(3, "Alice", "Johnson"),
        new User(4, "Bob", "Bobsky"),
    };


    public static void AddUser(string firstName, string lastName)
    {
        int newId = UsersDb.Max(u => u.Id) + 1;
        var newUser = new User(newId, firstName, lastName);

        UsersDb.Add(newUser);
    }

}
