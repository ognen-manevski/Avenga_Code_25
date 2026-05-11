using Class03.Static_Classes.Modals;
using Class03.Static_Classes.Helpers;

namespace Class03.Static_Classes
{
    public static class OrdersStaticDB
    {
        public static List<Order> Orders { get; set; } = new List<Order>();
        public static List<User> Users { get; set; } = new List<User>();

        private static int orderIdCounter;


        static OrdersStaticDB()
        {
            //seed some initial data
            ConsoleHelper.WriteInColor("Hello from OrdersStaticDB static Constructor!", ConsoleColor.DarkMagenta);

            Orders = new List<Order>
            {
                new Order { Id = 1, Title = "Order 1", Description = "Description for Order 1", Status = Enums.OrderStatus.Processing },
                new Order { Id = 2, Title = "Order 2", Description = "Description for Order 2", Status = Enums.OrderStatus.Delivered },
                new Order { Id = 3, Title = "Order 3", Description = "Description for Order 3", Status = Enums.OrderStatus.InProgress },
                new Order { Id = 4, Title = "Order 4", Description = "Description for Order 4", Status = Enums.OrderStatus.Cancelled },
                new Order { Id = 5, Title = "Order 5", Description = "Description for Order 5", Status = Enums.OrderStatus.Processing }
            };

            Users = new List<User>()
            {
                    new User{Id = 1, UserName = "JohnDoe", Address = "123 Main St" },
                    new User{Id = 2, UserName = "JaneSmith", Address = "456 Elm St" },
            };

            Users[0].Orders.Add(Orders[0]);
            Users[0].Orders.Add(Orders[1]);
            Users[0].Orders.Add(Orders[2]);
            Users[1].Orders.Add(Orders[3]);
            Users[1].Orders.Add(Orders[4]);

            orderIdCounter = Orders.Max(o => o.Id);
        }

        public static void ListUsers()
        {
            for (int i = 0; i < Users.Count; i++)
            {
                Console.WriteLine($"User {i + 1,3} | UserName: {Users[i].UserName,-20}");
            }
        }

        public static void InsertOrder(Order order, int userId)
        {
            User user = Users.SingleOrDefault(u => u.Id == userId); //single or default - returns the only element of a sequence,
                                                                    //or a default value if the sequence is empty;
                                                                    //this method throws an exception if there is more than one element in the sequence.

            if (user == null)
            {
                ConsoleHelper.WriteError("User not found");
                return;
            }

            order.Id = ++orderIdCounter; //auto increment id
            Orders.Add(order);
            user.Orders.Add(order);

            ConsoleHelper.WriteInColor($"Order successfully created", ConsoleColor.Green);
            ConsoleHelper.WriteInColor($"Total number of orders: {Orders.Count}", ConsoleColor.Green);
        }



    }
}



