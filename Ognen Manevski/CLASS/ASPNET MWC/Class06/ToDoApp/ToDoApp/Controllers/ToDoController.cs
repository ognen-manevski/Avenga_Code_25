using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers;

[Route("ToDos")]
public class ToDoController : Controller
{

    private readonly IToDoService _toDoService;

    public ToDoController(IToDoService toDoService)
    {
        //_toDoService = new ToDoService(new ToDoRepository());
        //this is not good because it creates a tight coupling between the controller and the service,
        //and it also creates a new instance of the service every time the controller is created.
        //Instead, we should use dependency injection to inject the service into the controller.
        _toDoService = toDoService;
    }

    [HttpGet]
    public IActionResult GetAllToDos([FromQuery] int? categoryId, [FromQuery] int? statusId)
    {
        var todos = _toDoService.GetAllToDos(categoryId, statusId);

        return View(todos);
    }

}
