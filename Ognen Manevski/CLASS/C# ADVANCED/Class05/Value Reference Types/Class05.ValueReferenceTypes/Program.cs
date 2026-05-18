using Class05.ValueReferenceTypes;

int num1 = 10;
int num2 = num1;
num2 = 10000;

Console.WriteLine(num1); // Output: 10
Console.WriteLine(num2); // Output: 10000

//int num3 = null; // This will cause a compile-time error because int is a value type and cannot be null
int? num3 = null; // This is valid because int? is a nullable type that can hold null values

string str3 = null; //ALL reference types can be null!

string str1 = "String1";
string str2 = str1;
str2 = "String2"; // This should not change str1 because strings are immutable in C#
                  // When we assign a new value to str2, it creates a new string object in memory, and str1 still references the original string "String1".
                  // but strings behave like value types!

Console.WriteLine(str1);
Console.WriteLine(str2);


Person bob  = new Person { Name = "Bob", Age = 30 };
Person alice = bob;
alice.Name = "Alice";

Console.WriteLine(bob.Name); // Output: Alice!!!!@# because bob and alice reference the same object in memory
Console.WriteLine(alice.Name); // Output: Alice