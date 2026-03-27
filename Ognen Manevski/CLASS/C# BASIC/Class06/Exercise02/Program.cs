using Class06.Utilities;
using Class06.Exercise02.Models;

//Task 2
//Create a class User with the following:

//Id - int
//Username - string
//Password - string
//Messages - Array of strings
//Create an array of users and add 3 users to it manually ( hard-coded ).

User[] usersArr = new User[]
{
    new User(23, "Marko", "MarkoPW123", new string[] { "Marko Msg 1", "Marko Msg 2" }),
    new User(44, "Sharko", "SharkoPW123", new string[] { "Sharko Msg 1", "Sharko Msg 2" }),
    new User(1, "Zharko", "ZharkoPW123", new string[] { "Zharko Msg 1", "Zharko Msg 2" }),
};

//Create a Console UI that will ask the user:

//Log in - When selected the user should be asked for username and password.
// If the user is found print welcome message and the messages that the user has in the Messages property:
//Welcome NAME. Here are your messages:
//Message1
//Message2
//If not found, it should print an error message

void LogIn()
{
    bool found = false;

    Console.WriteLine("Please enter Your Username:");

    while (!found)
    {
        string username = Console.ReadLine();

        if (ValidateUsername(username))
        {
            found = true;
            continue;
        }
        Console.WriteLine("Username not found. Please try again.");
    }

    Console.WriteLine("Please enter Your Password:");
    string pw = Console.ReadLine();
}

void LogIn2()
{
    User user = GetUserInput();

    if (user != null)
    {
        Console.WriteLine("===================================");
        Console.WriteLine($"Welcome {user.Username}");
        Console.WriteLine("===================================");
        Console.WriteLine("Your Messages:");
        foreach (string msg in user.Messages)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine(msg);
        }
        Console.WriteLine("===================================");
    }

}

User FindUser(string username, string pw)
{
    foreach (User user in usersArr)
    {
        if (user.Username.ToLower() == username.ToLower())
        {
            if (user.Password == pw) return user;
            Console.WriteLine("Incorrect Password.");
        }
    }
    Console.WriteLine("User not found.");
    return null;
}





bool ValidateUsername(string username)
{
    username = username.ToLower();

    bool found = false;

    while (!found)
    {
        if (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("Username cannot be empty. Please try again.");
            continue;
        }

        foreach (User user in usersArr)
        {
            if (user.Username == username)
            {
                found = true;
                break;
            }
        }
    }

    return found;
}


//Register - When selected the user should be asked to enter ID, Username and password.
// It should then check if a there is already a username in the array of users like that. If there is,
// print a message that there is already a user called like that. If not,
// create a new user object from the information given in the console and add it to the Users array.
// Then print all the users by Id and Username

void Register2()
{
    User user = GetUserInput();

    if (user != null)
    {
        Console.WriteLine("User already registered!");
        return;
    }

    Array.Resize(ref usersArr, usersArr.Length + 1);
    usersArr[usersArr.Length - 1] = new User(usersArr.Length, user.Username, user.Password, null);


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

}


User GetUserInput()
{
    Console.Write("Username: ");
    string username = Console.ReadLine();
    Console.Write("Password: ");
    string pw = Console.ReadLine();
    return FindUser(username, pw);
}


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




//static void Exercise02()
//{
//    bool exit = false;

//    while (!exit)
//    {
//        Console.WriteLine("Please LogIn or Register:");
//        Console.WriteLine(@$"
//        1. Log In
//        2. Register
//        ");
//    }
//}




bool UserUI()
{    
    double answ = Utilities.GetNumInput("1) LogIn\n2) Register New\n3) Exit");

    switch (answ)
    {
        case 1: LogIn2(); return true;
        case 2: Register2(); return true;
        case 3: return false;
        default: Console.WriteLine("Please enter a valid choice 1, 2 or 3"); return true;
    }
}

while (UserUI()) ;
