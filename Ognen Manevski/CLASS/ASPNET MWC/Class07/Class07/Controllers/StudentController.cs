using Class07.Database;
using Microsoft.AspNetCore.Mvc;
using Class07.Models.ViewModels;
using Class07.Helpers;

namespace Class07.Controllers;

[Route("students")]
public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        List<StudentVM> students = StaticDb.Students.Select(s =>
        Mapper.MapToStudentVM(s)).ToList();

        return View(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentById([FromRoute] int id)
    {
        var student = StaticDb.Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        var studentVM = Mapper.MapToStudentDetailsVM(student);

        return View("StudentDetails", studentVM);
    }

    [HttpGet("id")]
    public IActionResult GetStudentByIdWithQuery([FromQuery] int id)
    {
        var student = StaticDb.Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        var studentVM = Mapper.MapToStudentDetailsVM(student);

        return View("StudentDetails", studentVM);
    }

    [HttpGet("filterBy")]
    public IActionResult GetStudentFilter([FromQuery] StudentFilterVM studentFilterVm) //StudentFilterVM gets values from query
    {
        var student = StaticDb.Students.FirstOrDefault(s => (DateTime.Now.Year - s.DateOfBirth.Year) == studentFilterVm.Age &&
        s.GetFullName().ToLower() == studentFilterVm.FullName.ToLower());
        if (student == null)
        {
            return NotFound();
        }
        var studentVM = Mapper.MapToStudentDetailsVM(student);
        return View("StudentDetails", studentVM);
    }

    //[HttpGet("filterBy")]
    //public IActionResult GetStudentFilter(string fullName, int age)
    //{
    //    var student = StaticDb.Students.FirstOrDefault(s => DateTime.Now.Year - s.DateOfBirth.Year == age && s.GetFullName().ToLower() == fullName.ToLower());
    //    if (student == null)
    //    {
    //        return NotFound();
    //    }
    //    var studentVM = Mapper.MapToStudentDetailsVM(student);
    //    return View("StudentDetails", studentVM);
    //}

    //--------
    //CREATING A STUDENT REQUIRES a HTPPGET AND HTTP POST witht he same IActionResuklt:
    //--------

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm] CreateStudentVM createStudentVM)
    {
        //if true update and reroute
        if (ModelState.IsValid)
        {
            StaticDb.Students.Add(Mapper.MapToStudent(createStudentVM));
            return RedirectToAction("Index");
        }


        //if false return error view

        return View();

    }
}

