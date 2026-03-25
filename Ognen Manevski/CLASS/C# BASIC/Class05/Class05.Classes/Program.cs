using Class05.Classes.Models; //import namespace ALWAYS ON TOP OF FILE!

//===============================
#region Classes
//===============================

//create a Person object using the parameterless constructor
//and manually settig the properties
Person john = new Person();
john.FirstName = "John";
john.LastName = "Doe";
john.Age = 30;
john.Hobbies = ["Reading", "Hiking", "Cooking"];
//john.PhoneNumber = "123/456-789";
john.IsStudent = false;

Console.WriteLine($"{john.FirstName} {john.LastName} - {john.GetSSNValue()}");

Console.ReadLine();


//create a Person object using the object initializer syntax
Person bob = new Person()
{
    FirstName = "Bob",
    LastName = "Bobsky",
    Age = 25,
    PhoneNumber = "123/456-789",
    Hobbies = ["Gaming", "Traveling"],
    IsStudent = true
};

Console.WriteLine($"{bob.FirstName} {bob.LastName} is {bob.Age} years old. - {bob.GetSSNValue()}");

Console.ReadLine();


//create a Person object using the constructor with parameters
Person jill = new Person("Jill", "Wayne", "123/456-789", 28, [], true);

Console.WriteLine($"{jill.FirstName} {jill.LastName} is {jill.Age} years old. - {jill.GetSSNValue()}");


jill.Talk("Hello, I am Jill! Nice to meet you.");


#endregion
//===============================


//===============================
#region Working with Classes
//===============================

Group g1 = new Group("G1", 12, "Basic C#");
Group g2 = new Group("G2", 18, "Web Development using NodeJS");

Student mario = new Student("Mario Rossi", 22, g1);
Student dimitar = new Student("Dimitar Petrov", 24, g1);
Student tomi = new Student("Tomi Tomov", 21, g2);

Student ivo = new Student("Ivo Kostovski", 36, new Group("g3", 10, "HTML/CSS"));
Student ana = new Student("Ana Petrovska", 29, new Group()
{
    GroupName = "g4",
    NumberOfStudents = 15,
    CurrentSubjectName = "JavaScript"
});


mario.DisplayStudentInfo();
dimitar.DisplayStudentInfo();
tomi.DisplayStudentInfo();
ivo.DisplayStudentInfo();
ana.DisplayStudentInfo();


Student filip = new Student("Filip Mihajlovski", 27, null); //we dont know the group yet - null
filip.DisplayStudentInfo();


#endregion
//===============================
