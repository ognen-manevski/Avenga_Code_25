using System.Collections;
using Class08.Collections.Models;

static void PrintCollection(IEnumerable collection, string name)
{
    Console.WriteLine($"Collection {name} items:");

    foreach (var item in collection)
    {
        Console.Write($"{item}, ");
    }
    Console.WriteLine();
    Console.WriteLine(new string('-', 20));
}

static void PrintCollectionUsers(List<User> collection, string name)
{
    Console.WriteLine($"Collection {name} items:");

    foreach (var item in collection)
    {
        Console.WriteLine($"{item.FullName} - {item.Age}, ");
    }
    Console.WriteLine(new string('-', 20));
}

static void PrintCollection2<T>(List<T> collection, string name)
{
    Console.WriteLine($"Collection {name} items:");
    foreach (var item in collection)
    {
        Console.Write($"{item}, ");
    }
    Console.WriteLine();
    Console.WriteLine(new string('-', 20));
}



//========================================
#region Generic Collections - Lists 
//========================================


List<int> numbers = new List<int>();

numbers.Add(1);
numbers.Add(10);
numbers.Add(123);


numbers.AddRange(11, 22, 32, 43, 54);

//we cant use .Length -> we use .Count()
Console.WriteLine(numbers.Count);

PrintCollection(numbers, "List<int>");

numbers.Remove(32); // removes the first occurrence of 32
numbers.Remove(1234); //not found, does nothing + returns false

PrintCollection2(numbers, "List<int>");


//

List<string> names = new List<string>()
{
    "John",
    "Jane",
    "Jack",
    "Jill",
    "James"
};

PrintCollection(names, "List<string>");


// list of User objects

List<User> users = new List<User>()
{
    new User { Id = 1, FullName = "Bob Bobsky", Age = 30 },
    new User { Id = 2, FullName = "Alice Alinsky", Age = 25 },
    new User { Id = 3, FullName = "Charlie Chaplin", Age = 40 },
};

//deleting from the list

users.Remove(users[2]); // removes Charlie Chaplin
//users.RemoveAt(1); // removes Alice Alinsky

PrintCollectionUsers(users, "List<User>");


#endregion
//========================================

Console.Clear();

//========================================
#region Array Lists
//========================================

ArrayList mixedArray = new ArrayList()
{
    1, 10, true, false, new User(), "Hello"
}; 

mixedArray.Add(123); // adds 123 to the end of the ArrayList
mixedArray.AddRange(new object[] { 11, 22, 32, 43, 54 }); // adds multiple items to the end of the ArrayList
mixedArray.Remove(32); // removes the first occurrence of 32 -> returns void if not found

#endregion
//========================================

Console.Clear();

//========================================
#region Generic Collections - Dictionaries
//========================================

Dictionary<string, string> songList = new Dictionary<string, string>()
{
    { "Artist 1", "Song Name 1" },
    { "Artist 2", "Song Name 2" },
    { "Artist 3", "Song Name 3" },
};

Console.WriteLine(songList["Artist 1"]); //search by key -> returns value

if (songList.ContainsKey("Artist 4")) //true false //ContainsValue
{
    Console.WriteLine(songList["Artist 4"]);
}
else
{
    Console.WriteLine("Artist not found in the dictionary.");
}

var item = songList.TryGetValue("Artist 3", out string songName); //bool + out parameter

if (item)
{
    Console.WriteLine($"Your song was found: {songName}");
}
else
{
    Console.WriteLine("No such song available.");
}

Dictionary <int, string> students = new Dictionary<int, string>()
{
    { 1, "John Doe" },
    { 2, "Jane Smith" },
    { 3, "Alice Johnson" },
    { 4, "Jill Wayne" },
};

PrintCollection(students, "Dictionary of Student Items:");

foreach (var student in students)
{
    Console.WriteLine($"Key: {student.Key}, Value: {student.Value}");
}

Console.WriteLine();

//

Dictionary <int , User> trainers = new Dictionary<int, User>()
{
    { 1, new User { Id = 1, FullName = "Bob Bobsky", Age = 30 } },
    { 2, new User { Id = 2, FullName = "Greg Smith", Age = 25 } },
    { 3, new User { Id = 3, FullName = "John Doe", Age = 40 } },
};

foreach (var trainer in trainers)
{
    Console.WriteLine($"Key: {trainer.Key}, Value: {trainer.Value.FullName} - {trainer.Value.Age}");
}

#endregion
//========================================
Console.Clear();


//========================================
#region Generic Collections - Queue <>
//========================================

//first in first out (FIFO)

Queue<int> numbersQueue = new Queue<int>();

numbersQueue.Enqueue(1);
numbersQueue.Enqueue(2);
numbersQueue.Enqueue(34);
numbersQueue.Enqueue(65);
numbersQueue.Enqueue(98654);


numbersQueue.Dequeue(); // removes the first item (1) and returns it

PrintCollection(numbersQueue, "Queue of numbers");

numbersQueue.Peek(); // returns the first item without removing it and returns it


Console.WriteLine(numbersQueue.Count); //4 atm


#endregion
//========================================

Console.Clear();

//========================================
#region Generic Collections - Stack <>
//========================================

//last in first out (LIFO)

// ex. undo operations, back button in the browser, call stack

Stack<string> namesStack  = new Stack<string>();

namesStack.Push("Bob");
namesStack.Push("John");
namesStack.Push("Jill");
namesStack.Push("Alice");

namesStack.Pop(); // removes the last item (Alice) and returns it

PrintCollection(namesStack, "Stack of names");

Console.WriteLine(namesStack.Count);
Console.WriteLine(namesStack.Peek());


#endregion
//========================================



