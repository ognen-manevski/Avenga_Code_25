//=====================================
#region Strings
//=====================================

using System.Globalization; //we need to import this namespace to use CultureInfo for string formatting

string fname = "John";
string lname = "Smith";

//string concatenation
string hello1 = "Hello " + fname;

string hello2 = string.Format("Hello there {0} {1}", fname, lname);
Console.WriteLine(hello2);

//string interpolation
string hello3 = $"Hello there again {fname} {lname}";
Console.WriteLine(hello3);

//escaping characters in a string using backslash (\)
string msg1 = "check your c:\\drive ";
Console.WriteLine(msg1);

string msg2 = "We will have \"fair\" elections.";
Console.WriteLine(msg2);

string msg3 = "The \\n sign means new line in c#.";
Console.WriteLine(msg3);

string folderPath = "C:\\Users\\John\\AvengaAcademy\\C#Basic";
Console.WriteLine(folderPath);

//verbatim string literal
string folderPathNew = @"C:\Users\John\AvengaAcademy\C#Basic";
Console.WriteLine(folderPathNew);

//combining verbatim string literal with string interpolation
string avengaFolderName = "AvengaProjects";
string userName = "John123";
string pathToFolder = $@"C:\Users\{userName}\{avengaFolderName}";
Console.WriteLine(pathToFolder);

#endregion
//=====================================


//=====================================
#region String Formating
//=====================================

string myPercentageString = string.Format("This is {0:P}", 0.5); //{0:P} meants percentage, 0.5 will be converted to 50%
Console.WriteLine(myPercentageString); //50.00%
// {0:P0} - formatting the percentage with no decimal places,
// 0.5 will be converted to 50%

string myCurrencyValue = string.Format(new CultureInfo("en-US"), "This will cost me {0:C}", 123.45); //{0:C} means currency, 123.45 will be converted to $123.45
// new CultureInfo("en-US") is used
// to specify the culture for formatting the currency value,
// in this case, it will format the currency according to
// US standards (using $ as the currency symbol).
Console.WriteLine(myCurrencyValue);

string myStringNumber = string.Format("{0:N}", 12345.6789); //{0:N} means number, 12345.6789 will be formatted with commas and decimal places
Console.WriteLine(myStringNumber); //12,345.68

string cardNumber = string.Format("{0:####-####-####-####}", 1111222233334444);
//{0:####-####-####-####} is a custom format string
// with groups of four digits separated by hyphens.
Console.WriteLine(cardNumber); //1111-2222-3333-4444

string phoneNumber = string.Format("{0:0##/###-###}", 070222333); //number cant start with 0 so we add the 0 in the template
Console.WriteLine(phoneNumber); //070/222-333

string myCustomAlignedString1 = string.Format("| {0,10} | {1, 18} |", "id", "Order");
//{0,10} means that the first argument (id) will be right-aligned in a field of 10 characters
//{0,-10} means that the first argument (id) will be left-aligned in a field of 10 characters
string myCustomAlignedString2 = string.Format("| {0,10} | {1, 18} |", "25", "Samsung Galaxy S25");

Console.WriteLine(myCustomAlignedString1);
Console.WriteLine(myCustomAlignedString2);

#endregion
//=====================================

//=====================================
#region String Methods
//=====================================

string msg11 = "     We are learning C# and it is FUN and EASY. Okay maybe just FUN.   ";
Console.WriteLine(msg11.Length);
//removes leading and trailing whitespace characters from the string
Console.WriteLine(msg11.Trim().Length);
//original length: 77
//result: 68, all of the leading and trailing spaces are removed

string lower = msg11.ToLower(); //converts the string to lowercase
string upper = msg11.ToUpper(); //converts the string to uppercase
Console.WriteLine(lower);
Console.WriteLine(upper);

string[] splitted = msg11.Split('.'); //splits by '.' and returns an arr
Console.WriteLine(splitted[0]);
Console.WriteLine(splitted[1]);
Console.WriteLine(splitted[2]); //the empty characters after the last '.' are also included in the array

bool doesStringStartWith = msg11.Trim().StartsWith("W");
Console.WriteLine(doesStringStartWith);

int indexOfString = msg11.IndexOf("FUN"); //first occurence
Console.WriteLine(indexOfString);

int nonExistingString = msg11.IndexOf("nope"); // -1

string substring = msg11.Substring(0, 15); //start index, length
Console.WriteLine(substring);

char[] toChars = msg11.ToCharArray(); //converts the string to a char arr
Console.WriteLine(toChars.Length);
Console.WriteLine(string.Join("-", toChars));

#endregion
//=====================================

