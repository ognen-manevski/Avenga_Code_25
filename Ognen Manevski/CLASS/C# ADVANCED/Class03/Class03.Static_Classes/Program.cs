using Class03.Static_Classes;
using Class03.Static_Classes.Helpers;
using Class03.Static_Classes.Modals;
using Class03.Static_Classes.Enums;


//Console.ForegroundColor = ConsoleColor.Blue;
//Console.WriteLine("======= Welcome to Order Management System ===========");
//Console.ResetColor();

//ConsoleHelper consoleHelper = new ConsoleHelper(); //we must create an instance of ConsoleHelper to use its method, because it's not static class



Console.WriteLine(OrdersStaticDB.Users.Count);
Console.WriteLine(OrdersStaticDB.Orders.Count);

bool isRunning = true;

while (isRunning)
{
    ConsoleHelper.WriteInColor("======= Welcome to Order Management System ===========", ConsoleColor.Blue);
    Console.WriteLine("\nPlease choose an option:");
    Console.WriteLine("1. List Users");
    Console.WriteLine("2. Create order for user");
    Console.WriteLine("3. Exit");


    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            // List users
            ConsoleHelper.WriteInColor("\nList of users:", ConsoleColor.Magenta);
            OrdersStaticDB.ListUsers();
            break;
        case "2":
            // Create order for user
            ConsoleHelper.WriteInColor("\nEnter user ID:", ConsoleColor.Yellow);
            string userId = Console.ReadLine();

            ConsoleHelper.WriteInColor("Enter order title:", ConsoleColor.Yellow);
            string title = Console.ReadLine();

            ConsoleHelper.WriteInColor("Enter order description:", ConsoleColor.Yellow);
            string description = Console.ReadLine();

            Order newOrder = new Order
            {
                Title = title,
                Description = description,
                Status = OrderStatus.Processing
            };

            OrdersStaticDB.InsertOrder(newOrder, Convert.ToInt32(userId));


            break;
        case "3":
            // Exit
            ConsoleHelper.WriteInColor("Exiting the application. Goodbye!", ConsoleColor.DarkCyan);
            isRunning = false;
            return;
        default:
            // Invalid option
            ConsoleHelper.WriteError("Invalid option. Please try again.");
            break;
    }

}
