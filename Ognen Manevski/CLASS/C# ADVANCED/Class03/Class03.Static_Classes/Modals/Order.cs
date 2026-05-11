using Class03.Static_Classes.Enums;

namespace Class03.Static_Classes.Modals
{
    public class Order : BaseEntity
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }


        public string GetInfo()
        {
            return $"Title: {Title}, Description: {Description}, Status: {Status}";
        }

        public static bool IsValidOrder(Order order)
        {
            if (order == null) return false;
            if (string.IsNullOrWhiteSpace(order.Title)) return false;
            if (string.IsNullOrWhiteSpace(order.Description)) return false;
            return true;
        }


    }
}
