
#region value and reference types


using Class10.MemoryAllocation;

Console.WriteLine("================= STACK AND HEAP =================");


Console.WriteLine("================= Value and reference types =================");

Console.WriteLine("================= Value types =================");

int n1 = 10;
int n2 = n1;
n2 = 20;

Console.WriteLine(n1); // 10
Console.WriteLine(n2); // 20


Console.WriteLine("================= Reference types =================");

List<int> ints1 = [1, 2, 3];
List<int> ints2 = ints1;

ints2[1] = 100; //changes ints1[1] as well because ints1 and ints2 are referencing the same list in the heap

ints1.ForEach(Console.WriteLine); // 1, 2, 3 ?? -> NO its 1, 100, 3
ints2.ForEach(Console.WriteLine); // 1, 100, 3


//ex. User

User john = new User("John", "Malkovic", 30);

User john2 = john;
john2.Age = 32;

john.PrintInfo(); // John Malkovic, Age: 32
john2.PrintInfo(); // John Malkovic, Age: 32


Console.WriteLine("================= Strings =================");

string s1 = "String 1";
string s2 = s1;
s2 = "String 2";

Console.WriteLine(s1); // String 1
Console.WriteLine(s2); // String 2


#endregion

#region Object lifecycle

Console.WriteLine("================= Object lifecycle =================");


static void TestObjectFinalizer()
{
    User bob = new User("Bob", "Bobsky", 34);
    User john = new User(age: 34, lastName: "Smith", firstName: "John");

    Console.WriteLine("Logic with bob object...");
    bob.PrintInfo();
    Console.WriteLine("More logic...");
    john.PrintInfo();
    Console.WriteLine("Okay, we don't need the objects anymore. Throw them away.");
}

TestObjectFinalizer();

GC.Collect(); // we force the garbage collector to run

Console.ReadLine();


#endregion