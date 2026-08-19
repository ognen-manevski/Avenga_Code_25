using Microsoft.AspNetCore.Mvc;
using NotesApp.Domain.Enums;
using NotesApp.Dtos;
using NotesApp.Services.CustomExceptions;
using NotesApp.Services.Interfaces;

namespace NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    // GET: /api/notes
    // GET: /api/notes?priority=High
    // NOTE: priority is optional
    [HttpGet]
    public ActionResult<List<NoteDto>> GetAll([FromQuery] Priority? priority = null)
    {
        try
        {
            List<NoteDto> result = _noteService.GetAllNotes(priority);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error occured");
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<NoteDto> GetById([FromRoute] int id)
    {
        try
        {
            NoteDto note = _noteService.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        catch(NoteNotFoundException ex)
        {
            return NotFound(ex.Message);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error occured");
        }
    }


    //add
    [HttpPost]
    public ActionResult<NoteDto> Create([FromBody] AddNoteDto AddNoteDto)
    {
        try
        {

            NoteDto createdDto = _noteService.AddNote(AddNoteDto);

            return Ok(createdDto);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error occured");
        }
    }


    //update


    //delete

}
