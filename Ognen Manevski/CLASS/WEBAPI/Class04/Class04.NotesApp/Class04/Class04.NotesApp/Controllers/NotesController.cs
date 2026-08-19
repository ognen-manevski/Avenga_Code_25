using Class04.Domain.Enums;
using Class04.Dtos;
using Class04.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Class04.NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    // Constructor injection of the INoteService
    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    //GET: /api/notes
    [HttpGet]
    //Actionresult<T> when we know a type of the response we want to return, in this case a list of notes
    //IActionResult is a more generic type that can return any type of response, not just a specific type like List<Note>.
    public ActionResult<List<NoteDto>> GetAll([FromQuery] Priority? priority = null)
    {
        try
        {
            List<NoteDto> result = _noteService.GetAllNotes(priority);
            return Ok(result);
        }
        catch (Exception ex)
        {
            //logging the exception can be done here
            //NEVER return the ex.Message to the client in production, as it may contain sensitive information.
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. pls contact admin");
        }


    }



}
