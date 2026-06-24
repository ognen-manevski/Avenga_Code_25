using Avenga.ASP.NET.MVC.Class03.Services;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.ASP.NET.MVC.Class03.Controllers;


[Route("Students")]
public class StudentController : Controller
{
    private StudentService _studentService;

    public StudentController()
    {
        _studentService = new StudentService();
    }


    [HttpGet ("getById/{id:int}")]
    public IActionResult GetStudentById(int id)
    {
        var student = _studentService.GetStudentWithActiveCourse(id);
        if (student == null)
        {
            return Content("Student Not Found!"); //content -> plain txt
        }

        return Json(student);

    }
}
