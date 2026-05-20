using Class06.AnonymousMethods.Models;

List<string> names = new List<string> { "Alice", "Bob", "Charlie", "John", "Anna" };
List<string> empty = [];

// 1 line lambda expression
string johnName = names.Find(name => name == "John")!; //! <-- null forgiving operator, because Find can return null if not found

// Multiple line lambda expression
string john2Name = names.Find(name =>
{
    //return name == "John";
    if (name == "John")
    {
        return true;
    }
    return false;
})!;


// ================= Func =================

// in js:
// let sum = (a, b) => a + b;
// sum(2, 3); // 5

// in c#:
// Func is a delegate type that represents a method that returns a value and can take parameters
// Func <a, b, result>
Func<int, int, int> sumtest = (a, b) => a + b;

//example: func with 2 params:
Func<int, int ,int> sum = (a, b) => a + b;
int sumResult = sum(10, 20); // sumResult is 30

//with 1 param:
Func<List<string>, bool> isListEmpty = list => list.Count == 0;
Console.WriteLine("Is list empty? " + isListEmpty(empty)); //prints true
Console.WriteLine("Is list empty? " + isListEmpty(names)); //prints false


//without params:
// result is bool
Func<bool> isNamesEmpty = () => names.Count == 0; //false
Console.WriteLine("Is list names empty? " + isNamesEmpty()); 

////
Func<int, int, bool> isLarger = (a, b) => a > b;

//with 4 params:
Func<int, string, double, bool, string> getUserInfo = (id, name, salary, isActive) =>
{
    return $"ID: {id}, Name: {name}, Salary: {salary}, Active: {(isActive ? "Yes" : "No")}";
};

string userInfo = getUserInfo(1, "Bob", 3444.33, true);
Console.WriteLine(userInfo);

// example of a Func that uses class as type

Func<Person, string> getPersonName = person =>
{
    return person.Name;
};

Person alice = new Person { Name = "Alice"};
Console.WriteLine(getPersonName(alice));

// ================= void methods - Action =================

//void methods - Action is a delegate type that represents a method that does not return a value, but can take parameters

Action printHello = () => Console.WriteLine("Hello, World!");
printHello();

//with params:

// Action <param type> // not return type!

Action<string> printRed = word =>
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(word);
    Console.ResetColor();
};

printRed("Something went wrong!");

//

Action<string, ConsoleColor> printInColor = (text, color) =>
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
};

printInColor("This is blue text", ConsoleColor.Blue);
printInColor("This is green text", ConsoleColor.Green);


// ================= Predicate - bool =================

// Predicate is a delegate type that represents a method
// that returns a boolean value and can take parameters

Predicate<Person> isActive = person => person.IsActive; // returns true/false

Person bob2 = new ();
Console.WriteLine(isActive(bob2)); // false - default value of bool is false


// ================= Func & Action with hof and LINQ =================

// hof - higher order functions
// - functions that take other functions as parameters or return functions

string foundBob = names.Find(n => n == "Bob")!;


Predicate<string> isJill = name => name == "Jill";
string foundJill = names.Find(isJill); //null, because Jill is not in the list
                                       //we can pass a Predicate to Find method
                                       //!!cant use Func<string, bool> isJillFunc = name => name == "Jill";


Func<string, bool> isJillFunc = name => name == "Jill";
string foundJillFirst = names.FirstOrDefault(isJillFunc)!; //can use Func here


// filter by letter

Func<string, bool> startsWithJ = n => n.StartsWith("J");

List<string> namesWithJ = names.Where(startsWithJ).ToList(); //John //returns IEnumerable<string>, so we convert to List with ToList()

namesWithJ.ForEach(Console.WriteLine); // John //returns console output