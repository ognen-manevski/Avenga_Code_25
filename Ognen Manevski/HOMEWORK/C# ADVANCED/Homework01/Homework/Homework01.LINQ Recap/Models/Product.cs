
namespace Homework01.LINQ_Recap.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public ProductCategory Category { get; set; }

        public Product(int id, string title, string description, double price, double rating, int stock, string brand, ProductCategory category)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Rating = rating;
            Stock = stock;
            Brand = brand;
            Category = category;
        }
    }

    // Enum for Product Category
    public enum ProductCategory
    {
        Smartphones = 1,
        Laptops = 2,
        Fragrances = 3,
        Skincare = 4,
        Groceries = 5,
        HomeDecoration = 6
    }
}