//==========================================
#region Exercise 1
//==========================================

double x = 5;
double y = 10;

var div = x / y;

string string1 = "This is string 1";
string string2 = "This is string 2";

char str9 = '9';
char str3 = '3';


Console.WriteLine(
    $"X = {x}, Y = {y}, Result: {div} \n" +
    $"Concatenated 2 strings: {string1} {string2} \n" +
    $"Concatenated 9 and 3: {str9}{str3} "
    );


int num1 = 20;
int num2 = 0;

//var div2 = num1 / num2;
//compile time error

//Console.WriteLine(div2);
// This will throw a DivideByZeroException at runtime


#endregion
//==========================================


//==========================================
#region Exercise 2
//==========================================

//EXERCISE 2
//Declare an int and a string
//Initialize them and concatenate them
//Print the result in the console

int num3 = 20;
string str4 = "This is string 4";
Console.WriteLine("Concatenated sring and int:");
Console.WriteLine(num3 + str4);


#endregion
//==========================================


//==========================================
#region Exercise 3
//==========================================

//EXERCISE 3
//You have n credits on your mobile bill.
//One SMS costs m credits.
//n = 102
//m = 5
//How many SMS messages can you send?

int credits;
credits = 102;
int smsCost = 5;

var remainingMsgs = credits / smsCost;

Console.WriteLine(
    $"Number of credits: {credits} \n" +
    $"SMS cost: {smsCost} \n" +
    $"You can send {(remainingMsgs != 0 ? remainingMsgs + " message(s)" : "no messages")}"
    );

// what is @ in C#?
// The @ symbol in C# is used as a verbatim identifier.
// It allows you to use reserved keywords as variable names or to include special characters in string literals
// without needing to escape them.
// For example, you can declare a variable named @class or use a string like
// @"C:\Path\To\File.txt" without needing to escape the backslashes.


#endregion
//==========================================