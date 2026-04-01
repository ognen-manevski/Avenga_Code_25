using Class08.Linq.Models;

List<Student> students = new List<Student>()
{
    new Student(1, "John", "Doe", 20, "G1", Academy.WebDev, new List<string> { "C# Programming", "Databases", "Web APIs", "ASP.NET Core" }),
    new Student(2, "Jane", "Smith", 22, "G1", Academy.Design, new List<string> { "Graphic Design", "UI/UX Design", "Color Theory", "Typography" }),
    new Student(3, "Alice", "Johnson", 19, "G2", Academy.WebDev, new List<string> { "JavaScript", "Node.js", "SQL", "Web Security" }),
    new Student(4, "Bob", "Brown", 21, "G3", Academy.FrontEnd, new List<string> { "HTML/CSS", "React", "JavaScript", "Responsive Design" }),
    new Student(5, "Charlie", "Davis", 23, "G4", Academy.Design, new List<string> { "Adobe Photoshop", "Illustrator", "Branding", "User Research" }),
    new Student(6, "Eve", "Miller", 20, "G2", Academy.WebDev, new List<string> { "C# Programming", "Databases", "Web APIs", "ASP.NET Core" }),
    new Student(7, "Frank", "Wilson", 22, "G3", Academy.FrontEnd, new List<string> { "HTML/CSS", "React", "JavaScript", "Responsive Design" }),
    new Student(8, "Grace", "Taylor", 19, "G4", Academy.Design, new List<string> { "Graphic Design", "UI/UX Design", "Color Theory", "Typography" }),
    new Student(9, "Hank", "Anderson", 21, "G1", Academy.WebDev, new List<string> { "JavaScript", "Node.js", "SQL", "Web Security" }),
    new Student(10, "Ivy", "Thomas", 23, "G2", Academy.FrontEnd, new List<string> { "HTML/CSS", "React", "JavaScript", "Responsive Design" })
};


Student ivy = students.Where(x => x.Fname == "Ivy").First(); // like find in js
                                                             //first() because it returns a collection

Console.WriteLine($"{ivy.Fname} {ivy.Lname} - {ivy.Academy.ToString()}");

var allWebDevFromG1 = students
    .Where(x => x.Academy == Academy.WebDev && x.Group == "G1")
    .ToList();

//var is a list of students

foreach (var student in allWebDevFromG1)
{
    Console.WriteLine($"| Student: {$"{student.Fname} {student.Lname}".PadRight(20)} " +
        $"| Academy: {student.Academy.ToString().PadRight(10)} " +
        $"| Group: {student.Group.PadRight(10)} |");
}

var lastStudent = students.Last(); // returns a single object, not a collection

Console.WriteLine($" Last Student: {lastStudent.Fname} {lastStudent.Lname}");

var SubjectsOfAlice = students
    .Where(x => x.Fname == "Alice") //where returns a collection of students with the name Alice
    .Select(x => x.Subjects) //select returns a collection of collections of strings (list of lists of strings)
    .First(); //picks the first collection of strings (the subjects of the FIRST student named Alice)


Console.WriteLine("Subjects of Alice:");
foreach (var sub in SubjectsOfAlice)
{
    Console.WriteLine($" - {sub}");
}

//

var customSelection = students
    .Where(x => x.Fname == "Bob")
    .Select(x => new //anonimous object
    {
        FullName = $"{x.Fname} {x.Lname}",
        Academy = x.Academy,
        Subjects = x.Subjects
    })
    .FirstOrDefault(); //picks the first anonimous object (a?) created for a student named Bob

//FirstOrDefault -> if there is no student named "NonExistent", it will return null instead of throwing an exception

Console.WriteLine($"Subjects of {customSelection.FullName}:");

foreach (var sub in customSelection.Subjects)
{
    Console.WriteLine($" - {sub}");
}

//Single() -> if there is more than one student named "Bob", it will throw an exception because it expects only one result
//SingleOrDefault() -> if there is more than one student named "Bob", it will throw an exception because it expects only one result,
//but if there is no student named "Bob", it will return null instead of throwing an exception

