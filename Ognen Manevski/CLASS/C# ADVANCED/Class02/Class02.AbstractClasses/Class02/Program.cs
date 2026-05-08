using Class02.Domain.Interfaces;
using Class02.Domain.Models;
//=============================================================
#region Creating instances (objects)
//=============================================================


Developer dev = new Developer
    (
    "Bob",
    "Bobsky",
    35,
    "+1 123 456 78910",
    new List<string> { "JavaScript", "C#", "C++"}, //using the old C# syntax for creating a list of strings
    5
    );

Tester tester = new Tester
    (
    "Jill",
    "Wayne",
    24,
    "+1 987 654 3210",
    10
    );

Operations operations = new Operations
    (
    "Greg",
    "Gregsky",
    38,
    "+1 555 555 5555",
    ["Optimus", "ProtoBeat", "Abacus"] //also a list of strings, but using the new C# 14.0 syntax for array literals
    );


DevOps devOps = new DevOps
    (
    "John",
    "Doe",
    29,
    "+1 111 222 3333",
    false,
    true
    );

QAEngineer qaEngineer = new QAEngineer
    (
    "Steve",
    "Stevenson",
    34,
    "+1 444 555 6666",
    ["Selenium", "Playwright"]
    );


#endregion
//=============================================================

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(dev.GetInfo());
dev.Code();
dev.Greet("Buddy");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(qaEngineer.GetInfo());
qaEngineer.Code();
qaEngineer.TestFeature("Login");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(tester.GetInfo());

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(operations.GetInfo());

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(devOps.GetInfo());
devOps.Code();
Console.WriteLine(devOps.CheckInfrastructure(500) ? "Error occured!" : "Everything is fine");

Console.ResetColor();


#region using abstractions as types (bad practice)

IDeveloper seniorDev = new Developer
    (
    "Alice",
    "Smith",
    30,
    "+1 222 333 4444",
    ["Python", "Go"],
    7
    );

seniorDev.Code();

#endregion