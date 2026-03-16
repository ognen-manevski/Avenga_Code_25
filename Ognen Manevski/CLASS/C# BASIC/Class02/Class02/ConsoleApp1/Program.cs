//==========================================
#region
//==========================================

double a = 10;
double b = 202;

var sum = a + b;
var diff = a - b;
var multiply = a * b;
var divison = a / b;
//double because divison can be a decimal number
//but sum, diff, and multiply can be int because they will always be whole numbers

var complexExpression = (a + b) / (a - b) * multiply;    

Console.WriteLine(
    $" Sum: {sum} , \n" +
    $" Diff: {diff} , \n" +
    $" Multiply: {multiply} , \n" +
    $" Division: {divison}, \n" +
    $" Complex: {complexExpression}\n"
    );

var remainder = a % 7; // gives the remainder of the division of 10 by 7, which is 3
Console.WriteLine($"Remainder: {remainder} ");

Console.WriteLine($"b = {b}, b++ = {b++}"); //doesnt increment in the same line
Console.WriteLine($"b = {b}");
Console.WriteLine($"b++ = {b++}");

#endregion
//==========================================


