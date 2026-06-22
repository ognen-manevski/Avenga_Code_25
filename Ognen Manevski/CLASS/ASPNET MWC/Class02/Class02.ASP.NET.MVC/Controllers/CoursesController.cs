using Microsoft.AspNetCore.Mvc;
using Class02.ASP.NET.MVC.Models;

namespace Class02.ASP.NET.MVC.Controllers;

public class CoursesController : Controller
{

    private List<Course> _courses = new List<Course>()
    {
        new Course { Id = 1, Name = "C# Basics", NumberOfClasses = 10 },
        new Course { Id = 2, Name = "ASP.NET Core", NumberOfClasses = 15 },
        new Course { Id = 3, Name = "Entity Framework Core", NumberOfClasses = 12 },
    };

    //default http GET
    public IActionResult GetAllCourses() //localhost:port/Courses/GetAllCourses/
                                         //url is always compared in lowercase
    {
        return Json(_courses);
    }

    public IActionResult GetCourseById(int id) //localhost:port/Courses/GetCourseById/1
    {
        return Json(_courses.FirstOrDefault(c => c.Id == id));
    }

    public JsonResult GetCourseByName(string name)
    {
        return Json(_courses.FirstOrDefault(c => c.Name.ToLower() == name.ToLower()));
    }

    public IActionResult GetCourseByNameAndId(string name, int id)
    {
        return Json(_courses.FirstOrDefault(c => c.Name.ToLower() == name.ToLower() && c.Id == id));
    }


}

