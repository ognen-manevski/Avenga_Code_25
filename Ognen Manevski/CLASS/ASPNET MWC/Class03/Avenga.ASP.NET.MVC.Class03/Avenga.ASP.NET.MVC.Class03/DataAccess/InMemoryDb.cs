namespace Avenga.ASP.NET.MVC.Class03.DataAccess;

using Avenga.ASP.NET.MVC.Class03.Models.Domains;
public static class InMemoryDb
{
    public static List<Student> Students { get; set; } = new List<Student>(); //table students
    public static List<Course> Courses { get; set; } = new List<Course>(); //table courses

    static InMemoryDb() {
        LoadCourses();
        LoadStudents();
    }

    private static void LoadStudents()
    {
        Students = new List<Student>
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Now.AddYears(-20), ActiveCourse = Courses[3] },
            new Student { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = DateTime.Now.AddYears(-24), ActiveCourse = Courses[1] },
            new Student { Id = 3, FirstName = "Michael", LastName = "Johnson", DateOfBirth = DateTime.Now.AddYears(-39), ActiveCourse = Courses[2] },
            new Student { Id = 4, FirstName = "Emily", LastName = "Davis", DateOfBirth = DateTime.Now.AddYears(-22), ActiveCourse = Courses[0] },
            new Student { Id = 5, FirstName = "Daniel", LastName = "Brown", DateOfBirth = DateTime.Now.AddYears(-30), ActiveCourse = Courses[1] }
        };
    }

    private static void LoadCourses()
    {
        Courses = new List<Course>
        {
            new Course { Id = 1, Name = "C#", NumberOfClasses = 10 },
            new Course { Id = 2, Name = "Javascript", NumberOfClasses = 8 },
            new Course { Id = 3, Name = "ASP.NET", NumberOfClasses = 12 },
            new Course { Id = 4, Name = "MVC", NumberOfClasses = 15 }
        };
    }

}
