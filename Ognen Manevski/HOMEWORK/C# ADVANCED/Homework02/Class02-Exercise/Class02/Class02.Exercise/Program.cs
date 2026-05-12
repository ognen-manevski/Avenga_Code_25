/*
🧪 EXERCISE

Create:

    Interface IUser
        Id
        Name
        Username
        Password
        PrintUser() - Prints Id, Name and Username

    Interface IStudent
        Grades
        Override PrintUser() to show grades

    Interface ITeacher
        Subject
        Override PrintUser() to show subject

Create:

    Abstract class User and inherits from IUser
    Class Student that inherits from User and IStudent
    Class Teacher that inherits from User and ITeacher

Create:

    2 teacher objects
    2 student objects

Call:

PrintUser()

*/

using Class02.Domain.Models;

//teachers:
Teacher teacher1 = new Teacher
{
    Id = 1,
    Name = "John Doe",
    Username = "johndoe",
    Password = "password123",
    Subject = "Mathematics"
};

Teacher teacher2 = new Teacher
{
    Id = 2,
    Name = "Jane Smith",
    Username = "janesmith",
    Password = "password456",
    Subject = "History"
};

//students:
Student student1 = new Student
{
    Id = 1,
    Name = "Alice Johnson",
    Username = "alicejohnson",
    Password = "password789",
    Grades = new List<string> { "A", "B", "C" }
};

Student student2 = new Student
{
    Id = 2,
    Name = "Bob Bobsky",
    Username = "bobbobsky",
    Password = "password012",
    Grades = new List<string> { "B", "A", "A" }
};

//call print

teacher1.PrintUser();
teacher2.PrintUser();
student1.PrintUser();
student2.PrintUser();