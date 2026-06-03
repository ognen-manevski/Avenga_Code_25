using Class10.Nullables;

Console.WriteLine("=========== NULLABLES =================");

//int n = null; // error, value types cannot be null

// value types: int, double, bool, struct, enum

int n = 0; // value types cannot be null!

int? n1 = null; // nullable value type

double decimalNumber = 3.14;

//double decimalNumber2 = null; //error


bool? isTrue = null;

DateTime? dateTime = null;

string text = null; // reference types can be null
string? text2 = null; // nullable reference type, available in C# 8.0 and later


Person bob = new Person();
//bob will look like this:
//bob.Id = 0
//bob.Score = 0
//bob.Name = null ..............//reference type
//bob.IsEmployed = false
//bob.HasPet = false
//bob.Grades = null ............//reference types are initialized to null by default

//bob.Grades = new List<int>(); // we can initialize it to an empty list, so it won't be null

//we set int?
bob.Score = null;
