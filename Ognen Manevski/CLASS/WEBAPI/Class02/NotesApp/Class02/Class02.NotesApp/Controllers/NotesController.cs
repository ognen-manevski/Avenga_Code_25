using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class02.NotesApp.NewFolder;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    //get: https://localhost:5001/api/notes
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(StaticDb.SimpleNotes);
    }


    //get: https://localhost:5001/api/notes/1
    /// <summary>
    /// Gets a note by its ID.  
    /// </summary>
    /// <param name="id">The id of the note ebtity to be returned</param>
    /// <remarks></remarks>
    /// <response code="200">Returns the note by its id</response>
    /// <response code="404">Not Found</response>
    [HttpGet("{id}")]
    public ActionResult<string> GetById(int id)
    {
        if (id < 0 || id >= StaticDb.SimpleNotes.Count)
        {
            return NotFound(new
            {
                StatusCode = 404,
                Message = $"Note with id {id} was not found."
            });
        }

        var note = StaticDb.SimpleNotes[id];

        return Ok(note);
    }


    //GET: https://localhost:5001/api/notes/5/user/2
    [HttpGet("{noteId:int}/user/{userId:int}")]
    public ActionResult<string> GetNoteForUser(int noteId, int userId)
    {
        if (noteId < 0 || userId < 0 || noteId >= StaticDb.SimpleNotes.Count)
        {
            return NotFound(new
            {
                StatusCode = 404,
                Message = $"Note with id {noteId} and user with id {userId} was not found."
            });
        }

        var note = StaticDb.SimpleNotes[noteId];

        return Ok(
            $"Note with id {noteId} for user with id {userId} is: {note}"
            );
    }

    [HttpPost]
    //post: https://localhost:5001/api/notes
    public ActionResult Post()
    {
        try
        {
            using (StreamReader sr = new StreamReader(Request.Body))
            {
                string newNote = sr.ReadToEnd();


                if (string.IsNullOrEmpty(newNote))
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Note cannot be empty."
                    });
                }

                StaticDb.SimpleNotes.Add(newNote);

                //return Created();
                return StatusCode(
                    StatusCodes.Status201Created, new
                    {
                        StatusCode = 201,
                        Message = $"The note was created successfully! \n {newNote}"
                    });
                //we can return an object here too, but we will keep it simple for now
            }
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = 500,
                    Message = "An error occurred while processing the request.",
                    Exception = ex.ToString()
                });
        }
        //paste this url for testing with request body:
        //https://localhost:5001/api/notes/
    }



}
