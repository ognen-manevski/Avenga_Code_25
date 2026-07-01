using Microsoft.AspNetCore.Mvc;
using Class04.Views.Database;
using Class04.Views.Models.Dto;
using Class04.Views.Models.ViewModels;
using Class04.Views.Models.Domain;

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

    [HttpGet("create")] //GET: students/create
    public IActionResult CreateStudent()
    {
        return View(); //empty
    }

    [HttpPost("create")] //must be the same route as the GET method ^
    public IActionResult CreateStudent(CreateStudentVM model) //AND have the SAME NAME as the GET method ^
    {
        //map VIEW model to DOMAIN model
        var entity = new Student
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            Id = InMemoryDatabase.Students.Count + 1, //auto increment
            ActiveCourse = InMemoryDatabase.Courses[1]
        };

        // Add the new student to the in-memory database
        InMemoryDatabase.Students.Add(entity);


        //redirect back to view all students page
        //return View(); <- NO
        return RedirectToAction("GetAllStudents");
    }




}
