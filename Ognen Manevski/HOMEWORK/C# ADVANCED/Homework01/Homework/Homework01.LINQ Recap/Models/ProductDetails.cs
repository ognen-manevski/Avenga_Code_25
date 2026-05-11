//17.Create new class ProductDetails with 3 properties: Id, Title and Price and map the existing product data to a collection of ProductDetails objects.

namespace Homework01.LINQ_Recap.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        //ctor

        public ProductDetails(int id, string title, double price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

    }

}
