//namespace Class04.ExtensionMethods.Helpers.Piggybacking;
namespace Class04.ExtensionMethods; //we can put this in the main namespace so we dont have to add another using statement

using Class04.Generics.Domain.Models;

public static class ProductExtensions
{
    public static void PrintInfo(this Product product)
    {
        Console.WriteLine(product.GetInfo());
    }
}
//so waht is piggybacking? it's when we add new functionality to an existing class without modifying the original class,
//by creating an extension method for that class.
//In this case, we are adding a new method called PrintInfo to the Product class,
//which allows us to print the product's information in a specific format.
//This way, we can enhance the functionality of the Product class without changing its original implementation.
//so its just extension methods, but we are "piggybacking" on the existing class to add new functionality without modifying it.