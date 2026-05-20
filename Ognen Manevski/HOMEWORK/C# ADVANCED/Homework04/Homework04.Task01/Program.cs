/*
 Task 1
    Create class PrintInConsole that will have multiple methods to print in console: Print(), PrintCollection().
    Make these methods to be valid for more than one type and use them accordingly with different types.
 */

using Homework04.Task01;

//types
string string1 = "Hello";
int int1 = 1;
bool bool1 = false;


//collections
List<string> stringList = new List<string>() { "Dog", "Cat", "Bird" };
List<int> numbersList = new List<int>() { 1, 2, 3 };
string[] stringArray = new string[] { "Car", "Cat", "Cart" };
Dictionary<string, string> people = new Dictionary<string, string> {
        { "John", "Smith" },
        { "Jane", "Doe" },
        { "Alice", "Johnson" }
};
string string2 = "ABCDEF";


//print types
PrintInConsole.Print(string1);
PrintInConsole.Print(int1);
PrintInConsole.Print(bool1);

//Print collections
PrintInConsole.PrintCollection(stringList);
PrintInConsole.PrintCollection(numbersList);
PrintInConsole.PrintCollection(stringArray);
PrintInConsole.PrintCollection(people);
PrintInConsole.PrintCollection(string2);
