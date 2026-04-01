/*
 Create a PhoneBook Dictionary with 5 names and phone numbers.

Through the console ask the person to enter a name.

Try and find that name's phone number in your PhoneBook:

If you can find it, print it
If you can’t, print an error message
 */

Dictionary<string, string> phoneBook = new Dictionary<string, string>()
{
    {"John Doe", "123-456-7890"},
    {"Jane Smith", "987-654-3210"},
    {"Alice Johnson", "555-123-4567"},
    {"Bob Brown", "444-555-6666"},
    {"Charlie Davis", "111-222-3333"}
};


Console.WriteLine("Enter a name to search for their phone number:");

string name = Console.ReadLine();

var trySearch = phoneBook.TryGetValue(name, out string number);

if (trySearch)
{
    Console.WriteLine($"Phone number found: {name} - {number}");
}
else
{
    Console.WriteLine("No such name was found.");
}
