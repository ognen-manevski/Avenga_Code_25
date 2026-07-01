using Microsoft.AspNetCore.Mvc;
using Class04.Views.Models.Dto;
using Class04.Views.Database;


namespace Class04.Views.Controllers;

[Route("courses")]
public class CoursesController : Controller
{
    public IActionResult Index()
    {
        var courses = InMemoryDatabase.Courses;
        var coursesList = new List<CourseWithStudentsDto>();

        foreach (var course in courses)
        {
            var students = InMemoryDatabase.Students
                .Where(x => x.ActiveCourse.Id == course.Id)
                .Select(x => new StudentDto()
                {
                    FullName = $"{x.FirstName} {x.LastName}",
                    Age = DateTime.Now.Year - x.DateOfBirth.Year
                })
                .ToList();

            coursesList.Add(new CourseWithStudentsDto()
            {
                Id = course.Id,
                Name = course.CourseName,
                Students = students
            });
        }

        return View(coursesList);

    }
}
