namespace Avenga.ASP.NET.MVC.Class03.Models.DTOs;

public class StudentWithCourseDto
{
    public int Id { get; set; } //we need this for database
    public string FullName { get; set; }
    public int Age { get; set; }
    public string NameOfActiveCourse { get; set; }
}
