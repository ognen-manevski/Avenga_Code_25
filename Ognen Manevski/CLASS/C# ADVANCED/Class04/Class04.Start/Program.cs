using Class04.Generics.Domain.Data;
using Class04.Generics.Domain.Models;
using Class04.Generics.Helpers;

List<int> numbers = new () { 1, 2, 3, 4, 5 };
List <string> strings = [ "Alice", "Bob", "Charlie" ];
List<bool> bools = new List<bool> { true, false, true };

//non generic

NonGenericListHelper helper = new NonGenericListHelper();
helper.PrintInts(numbers);
helper.PrintStrings(strings);
helper.PrintBools(bools);

helper.PrintInfoForStrings(strings);
helper.PrintInfoForIntegers(numbers);
helper.PrintInfoForBools(bools);

// with generics + static

GenericListHelper.PrintItems(numbers);
GenericListHelper.PrintItems(strings);
GenericListHelper.PrintItems(bools);

GenericListHelper.PrintInfoForList(numbers);
GenericListHelper.PrintInfoForList(strings);
GenericListHelper.PrintInfoForList(bools);

//
Console.WriteLine("\n==================\n");

GenericDB<Product> ProductsDb  = new GenericDB<Product>();
GenericDB<Order> OrdersDb  = new GenericDB<Order>();


OrdersDb.Insert(new Order { Id = 1, Address = "123 Main St", Receiver = "John Doe" });
OrdersDb.Insert(new Order { Id = 2, Address = "456 Elm St", Receiver = "Jane Smith" });
OrdersDb.Insert(new Order { Id = 3, Address = "789 Oak St", Receiver = "Jill Wayne" });

ProductsDb.Insert(new Product { Id = 1, Title = "Laptop", Description = "High-end gaming laptop" });
ProductsDb.Insert(new Product { Id = 2, Title = "Smartphone", Description = "Latest model smartphone" });
ProductsDb.Insert(new Product { Id = 3, Title = "Tablet", Description = "10-inch tablet" });

OrdersDb.PrintAll();
ProductsDb.PrintAll();

//

//GenericDB<string> StringDb = new GenericDB<string>();
//GenericDB<Developer> DeveloperDb = new GenericDB<Developer>();