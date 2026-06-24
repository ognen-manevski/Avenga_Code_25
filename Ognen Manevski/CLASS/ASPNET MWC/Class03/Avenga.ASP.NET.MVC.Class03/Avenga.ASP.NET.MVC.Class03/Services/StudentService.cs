namespace Avenga.ASP.NET.MVC.Class03.Services;

using Avenga.ASP.NET.MVC.Class03.DataAccess;
using Avenga.ASP.NET.MVC.Class03.Models.Domains;
using Avenga.ASP.NET.MVC.Class03.Models.DTOs;

public class StudentService
{

    //not a good practice:

    //public Student GetStudentWithActiveCourse (int id)
    //{
    //    var student = InMemoryDb.Students.FirstOrDefault(s => s.Id == id);

    //    if (student == null)
    //    {
    //        return null;
    //        throw new Exception($"Student with id {id} not found.");
    //    }
    //    return student;
    //}

    public StudentWithCourseDto GetStudentWithActiveCourse(int id)
    {
        var student = InMemoryDb.Students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return null;
            throw new Exception($"Student with id {id} not found.");
        }

        var studentDto = new StudentWithCourseDto
        {
            Id = student.Id,
            FullName = $"{student.FirstName} {student.LastName}",
            Age = DateTime.Now.Year - student.DateOfBirth.Year,
            NameOfActiveCourse = student.ActiveCourse?.Name ?? "No active course"
        };

        return studentDto;
    }

}
