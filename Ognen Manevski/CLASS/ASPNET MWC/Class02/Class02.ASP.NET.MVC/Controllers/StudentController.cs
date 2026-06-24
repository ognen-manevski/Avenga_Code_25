using Class02.ASP.NET.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class02.ASP.NET.MVC.Controllers;

[Route("students")] // This is the route for the controller, it will be used to access the controller's actions
public class StudentController : Controller
{
    private List<Student> _students = new List<Student>
    {
        new Student()
        {
            Id = 1,
            FirstName = "Bob",
            LastName = "Bobski",
            DateOfBirth = DateTime.Now.AddYears(-27)
        },
        new Student()
        {
            Id = 2,
            FirstName = "Jill",
            LastName = "Jilski",
            DateOfBirth = DateTime.Now.AddYears(-37)
        },
        new Student()
        {
            Id = 3,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = DateTime.Now.AddYears(-45)
        },
        new Student()
        {
            Id = 4,
            FirstName = "Jane",
            LastName = "Doe",
            DateOfBirth = DateTime.Now.AddYears(-17)
        },
    };

    [Route("all")] //students/all
    [HttpGet("all")] //students/all -> same but newer; we dont have to say HttpPut or HttpPost separately
    public IActionResult GetAllStudents()
    {
        return Json(_students);
    }

    //students/getById/1 or students/1 - custom route with parameter
    [HttpGet("getById/{id:int:min(1)}")]
    [HttpGet("{id:int:min(1)}")] //we can have both
    public IActionResult GetById(int id)
    {
        return Json(_students.FirstOrDefault(s => s.Id == id));
    }


    //we can also return a student object directly for other purposes
    public Student GetStudentByIdAndName(int id, string name)
    {
        return _students.FirstOrDefault(s => s.Id == id && s.FirstName == name);
    }

    [Route("byId/{id?}")]
    public Student GetStudentByIdWithDefaultValue (int id = 1)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

}
