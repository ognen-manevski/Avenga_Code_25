//========================================
#region Arrays
//========================================

//Declaration of an array in C#
using System.Collections;

int[] emptyNumbersArray = new int[3];

//Initialization of array elements
emptyNumbersArray[0] = 1;
emptyNumbersArray[1] = 10;
emptyNumbersArray[2] = 20;

//cant add a new element on non existing index
//emptyNumbersArray[3] = 50;

for (int i = 0; i < emptyNumbersArray.Length; i++)
{
    Console.Write(emptyNumbersArray[i] + ", ");
}
Console.Write("\n");


string[] names = new string[]
{
    "John",
    "Jane",
    "Doe",
};

foreach (string name in names)
{
    Console.WriteLine(name);
}


double[] decimalNumbers = [10.5, 20.3, 30.7];

foreach (double num in decimalNumbers)
{
    Console.WriteLine(num);
}

// Mixed type array using object type

var mixedArray = new object[] { 1, "Hello", 3.14, true };

foreach (var obj in mixedArray)
{
    Console.WriteLine(obj);
}

ArrayList mixed = new ArrayList { 1, "Hello", 3.14, true };


#endregion
//========================================


//========================================
#region Array Methods
//========================================

Console.WriteLine("======= Array Methods =======");

int[] evenNumbers = new int[] { 2, 4, 6, 8, 10, 2, 4, 6 };

// reverse the array
Console.WriteLine("Array of even numbers after reverse");

Array.Reverse(evenNumbers);

foreach (var num in evenNumbers)
{
    Console.WriteLine(num);
}

//find index of an element in the array

int indexFound = Array.IndexOf(evenNumbers, 2);
Console.WriteLine("The index of number 2 is " + indexFound);


#endregion
//========================================


//========================================
#region Array Resize Methods
//========================================

Console.Clear();

string[] usernames = new string[0];

do
{
    Console.WriteLine("Please enter a Username");
    string userInput = Console.ReadLine();

    Array.Resize(ref usernames, usernames.Length + 1);
    usernames[usernames.Length - 1] = userInput;

    Console.WriteLine("Do you want to insert another username? y/n");

    userInput = Console.ReadLine();

    if (userInput == "n" || userInput == "N") break;

} while (true);


Console.Clear();

foreach (string username in usernames)
{
    Console.WriteLine(username);
}


int[] test = new int[] { 1, 2, 3, 4, 5 };

Array.Resize(ref test, 10);

test[5] = 10;
test[6] = 11;
test[7] = 12;
test[8] = 13;
test[9] = 14;
test[10] = 15;


//array of arrays (matrix)
int[][] arrayOfArrays = new int[][] 
{ 
    new int[] { 1, 2, 3 },
    new int[] { 1, 2, 3 },
    new int[] { 1, 2, 3 },
};


#endregion
//========================================