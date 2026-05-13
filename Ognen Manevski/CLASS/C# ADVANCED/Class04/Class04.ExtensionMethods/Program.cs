using Class04.ExtensionMethods.Helpers;

List<int> numbers = new() { 1, 2, 3, 4, 5 };
List<string> strings = ["Alice", "Bob", "Charlie"];

//ListHelper.PrintItems<int>(numbers);
//ListHelper.PrintItems<string>(strings);

numbers.PrintItems(); //

//numbers.PrintItems();