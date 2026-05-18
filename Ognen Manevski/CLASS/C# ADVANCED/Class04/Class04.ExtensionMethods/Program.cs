using Class04.ExtensionMethods.Helpers;
using Class04.Generics.Domain.Models;
using Class04.ExtensionMethods;

List<int> numbers = new() { 1, 2, 3, 4, 5 };
List<string> strings = ["Alice", "Bob", "Charlie"];

//ListHelper.PrintItems<int>(numbers);
//ListHelper.PrintItems<string>(strings);

numbers.PrintItems();
strings.PrintItems();

numbers.PrintListInfo();
strings.PrintListInfo();


string bobLong = "Bob Bobsky";
string bobShort = bobLong.Truncate(3);
Console.WriteLine(bobShort);
Console.WriteLine("Bob Bobsky".Truncate(2));
StringExtensions.Truncate("Bob Bobsky", 4); //directly

Console.WriteLine(bobLong.Quote());

Product product = new Product()
{
    Id = 1,
    Description = "A nice product",
    Title = "Product 1"
};

product.PrintInfo();
