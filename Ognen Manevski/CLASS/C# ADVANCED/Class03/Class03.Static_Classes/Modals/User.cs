using Class03.Static_Classes.Helpers;

namespace Class03.Static_Classes.Modals
{
    public class User : BaseEntity
    {
        //public int Id { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public User()
        {
            
        }

        public User(string userName, string address, List<Order> orders)
            //: base() { int id};
        {            
            UserName = userName;
            Address = address;
            Orders = orders;
        }

        public void PrintOrders()
        {
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine($"Orders of {UserName}:");
            //Console.ResetColor();

            ConsoleHelper.WriteInColor($"Orders of {UserName}:", ConsoleColor.Cyan);

            for (int i = 0; i< Orders.Count; i++)
            {
                Console.WriteLine($"Order {i + 1, 3} | {Orders[i].GetInfo(), -100} |");                
            }
        }

    }
}
