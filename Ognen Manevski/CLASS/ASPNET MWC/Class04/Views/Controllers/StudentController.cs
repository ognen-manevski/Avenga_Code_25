using Microsoft.AspNetCore.Mvc;
using Class04.Views.Database;
using Class04.Views.Models.Dto;

namespace Class04.Views.Controllers;

[Route("Students")]
public class StudentController : Controller 
{
    public IActionResult GetAllStudents()
    {
        var students = InMemoryDatabase.Students.Select (x =>
        new StudentWithCourseDto(x.Id, x.FirstName, x.LastName, x.DateOfBirth, x.ActiveCourse.Id, x.ActiveCourse.CourseName)
        );

        return View(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentById(int id)
    {
        var student = InMemoryDatabase.Students.FirstOrDefault(x => x.Id == id);

        if(student == null)
        {
            return View();
        }

        var studentDto = new StudentWithCourseDto(student.Id, student.FirstName, student.LastName, student.DateOfBirth, student.ActiveCourse.Id, student.ActiveCourse.CourseName);

        return View(studentDto);

    }



}
