//======================================================
#region DataTypes
//======================================================

int number = 154;
int otherNumber = 123353344;
long bigNumber = 3213123123113213131;
double decimalNumber = 3.14;
// The double data type can hold a large number of decimal places,
// but it is not as precise as the decimal data type.
// It is a floating-point type that uses 64 bits to store the value,
// which allows it to represent a wide range of values, but it can also lead
// to rounding errors when performing calculations with very large or very small numbers.

float decimalNumber2 = 33424.212312312F;
// The F at the end is required to indicate that this is a float literal,
// otherwise it would be treated as a double by default.

decimal decimalNumber3 = 3.14342342342342M;
// The M at the end is required to indicate that this is a decimal literal,
// otherwise it would be treated as a double by default. The decimal data type is a high-precision
// floating-point type that uses 128 bits to store the value, which allows it to represent a wide range
// of values with a high degree of accuracy,
// making it ideal for financial and monetary calculations where precision is important.

short shortNumber = 32767; // -32768 to 32767
bool isRaining = true; // false

string name = "John Doe"; // ""
string lastName;
lastName = "Smith";
Console.WriteLine(lastName);
char initial = 'M'; // ''
char character1 = 'm';


Console.WriteLine($"Int: {number}, ");
Console.WriteLine($"Int: {otherNumber}, ");
Console.WriteLine($"Long: {bigNumber}, ");
Console.WriteLine($"Double: {decimalNumber}, ");
Console.WriteLine(
    $"ShortNumber: {shortNumber}, \n" +
    $"IsRaining: {isRaining}, \n" +
    $"Float: {decimalNumber2}, \n" +
    $"Decimal: {decimalNumber3}, \n" +
    $"String: {name}, \n" +
    $"Char: {initial}, \n" +
    $"Char2: {character1}, \n"
    );


#endregion
//======================================================


//======================================================
#region Implicit Data Types
//======================================================
// Implicit data types are a feature of C#
// that allows the compiler to infer the type
// of a variable based on the value assigned to it.

var avengaAcademy = "Avenga Academy";

// AvengaAcademy = 10;
// This will cause a compile-time error because
// the compiler inferred that AvengaAcademy is of type string,

var number2 = 123;
number2 = 456; // This is allowed because number2 is of type int

var isSunny = true;
Console.WriteLine($"IsSunny? {isSunny}");
isSunny = false;
Console.WriteLine($"IsSunny? {isSunny}");


#endregion
//======================================================

//======================================================
#region Checking Data Types
//======================================================

Console.WriteLine($"Type of isRaining var: {isRaining.GetType()}");

#endregion
//======================================================