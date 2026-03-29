using Homework06.Utilities;
using Homework06.ClassExercise02_Refactored.Models;

//================================================
#region Task Description
//================================================
//Task 2
//Create a class User with the following:

//Id - int
//Username - string
//Password - string
//Messages - Array of strings
//Create an array of users and add 3 users to it manually ( hard-coded ).

//Create a Console UI that will ask the user:

//Log in - When selected the user should be asked for username and password.
//If the user is found print welcome message and the messages that the user has in the Messages property:
//Welcome NAME. Here are your messages:
//Message1
//Message2
//If not found, it should print an error message

//Register - When selected the user should be asked to enter ID, Username and password.
// It should then check if a there is already a username in the array of users like that. If there is,
// print a message that there is already a user called like that. If not,
// create a new user object from the information given in the console and add it to the Users array.
// Then print all the users by Id and Username

//Registration complete! Users:
//23 Username1
//44 Username2
//1 Username3
//56 Username4


//🧠 Design Hint – Separate Methods
//Think in terms of features, not lines of code:

//One method for showing the menu
//One method for login logic
//One method for registration logic
//One method for printing users
//One helper method for finding a user


#endregion
//================================================


//users init
User[] usersArr = new User[]
{
    new User(23, "Marko", "123", new string[] { "Marko Msg 1", "Marko Msg 2" }),
    new User(44, "Sharko", "123", new string[] { "Sharko Msg 1", "Sharko Msg 2" }),
    new User(1, "Zharko", "123", new string[] { "Zharko Msg 1", "Zharko Msg 2" }),
};

//User UI Loop
bool UserUI()
{
    double answ = Utilities.GetNumInput("1) LogIn\n2) Register New\n3) Exit");

    switch (answ)
    {
        case 1: LogIn(); return true;
        case 2: Register(); return true;
        case 3: return false;
        default: Console.WriteLine("Please enter a valid choice 1, 2 or 3"); return true;
    }
}

while (UserUI()) ;

void LogIn()
{
    bool found = false;
    User user = null;

    Console.WriteLine("Please enter Your Username:");

    while (!found)
    {
        string username = Console.ReadLine();

        if (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("Username cannot be empty. Please try again.");
            continue;
        }

        user = FindByUsername(username);

        if (user != null)
        {
            found = true;
            continue;
        }
        Console.WriteLine("Username not found. Please try again.");
    }

    Console.WriteLine("Please enter Your Password:");

    int attempts = 3;

    while (attempts > 0)
    {
        string pw = Console.ReadLine();

        if (string.IsNullOrEmpty(pw))
        {
            Console.WriteLine("Password cannot be empty. Please try again.");
            continue;
        }

        if (user.Password == pw)
        {
            PrintLoggedIn(user);
            return;
        }

        attempts--;
        if (attempts >= 1)
        {
            Console.WriteLine($"Incorrect Password. Attempts remaining: {attempts}");
            Console.WriteLine("Try again:");
        }
    }

    Console.WriteLine("Too many failed attempts. Returning to main menu.");
}

//========= LogIn() Helpers =============
#region LogIn() Helpers
//=======================================

User FindByUsername(string username)
{
    foreach (User user in usersArr)
    {
        if (user.Username == username)
        {
            return user;
        }
    }
    return null;
}

void PrintLoggedIn(User user)
{
    Console.WriteLine("===================================");
    Console.WriteLine($"Welcome {user.Username}");
    Console.WriteLine("===================================");
    Console.WriteLine("Your Messages:");
    if (user.Messages == null || user.Messages.Length == 0)
    {
        Console.WriteLine("No messages for you yet!");
    }
    else
    {
        foreach (string msg in user.Messages)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine(msg);
        }
    }
    Console.WriteLine("===================================");
}

#endregion
//=======================================

void Register()
{
    bool found = false;
    User user = null;
    string username = null;
    string password = null;

    Console.WriteLine("Please enter Your Username:");

    while (!found)
    {
        username = Console.ReadLine();

        if (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("Username cannot be empty. Please try again.");
            continue;
        }

        user = FindByUsername(username);

        if (user != null)
        {
            Console.WriteLine("Username not available. Please try a different username:");
            continue;
        }

        found = true;
    }

    Console.WriteLine("Please Enter your Password:");
    while (true)
    {
        password = Console.ReadLine();
        if (!string.IsNullOrEmpty(password)) break;
        Console.WriteLine("Password cannot be empty. Please try again.");
    }

    Array.Resize(ref usersArr, usersArr.Length + 1);
    usersArr[usersArr.Length - 1] = new User(usersArr.Length, username, password, new string[] { $"Welcome {username}" });

    PrintRegistered();
}

//========= Register() Helpers =============
#region Register() Helpers
//=======================================

void PrintRegistered()
{
    Console.WriteLine("===================================");
    Console.WriteLine("Successfully Registered!");
    Console.WriteLine("===================================");
    Console.WriteLine("Users registered so far:");
    Console.WriteLine("-----------------------------------");
    foreach (User u in usersArr)
    {
        Console.WriteLine($"ID: {u.ID} | Username: {u.Username}");
    }
    Console.WriteLine("-----------------------------------");

    Console.WriteLine("Press any key to return to Main Menu:");
    Console.ReadLine();
}

#endregion
//=======================================
