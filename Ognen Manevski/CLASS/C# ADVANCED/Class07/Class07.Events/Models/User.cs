using Class07.Events.Enums;

namespace Class07.Events.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public ProductType FavouriteProductType { get; set; }

    public User(int id, string name, string email, int age, ProductType favouriteProductType)
    {
        Id = id;
        Name = name;
        Email = email;
        Age = age;
        FavouriteProductType = favouriteProductType;
    }

    public void ReadPromotion(ProductType productType)
    {
        Console.WriteLine($"Mr/Mrs {Name}, the products of type {productType} are on promotion!");

        if (productType == FavouriteProductType)
        {
            Console.WriteLine("MY FAVOURITE PRODUCTS !!!");
        }
    }

}
