namespace Class04.Views.Models.Dto;

using Class04.Views.Models.Domain;
public class StudentWithCourseDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public int CourseId { get; set; }
    public string CourseName { get; set; }

    //mapping
    public StudentWithCourseDto(int id, string FirstName, string LastName, DateTime dateOfBirth, int courseId, string courseName)
    {
        Id = id;
        FullName = $"{FirstName} {LastName}";
        Age = DateTime.Now.Year - dateOfBirth.Year;
        CourseId = courseId;
        CourseName = courseName;
    }
}
