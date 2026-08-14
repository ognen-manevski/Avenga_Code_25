using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Class03.NotesAndTagsApp.Models;
using Class03.NotesAndTagsApp.Data;

namespace Class03.NotesAndTagsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        [HttpGet]
        //https://localhost:5001/api/notes
        public ActionResult<List<Note>> Get()
        {
            try
            {
                return Ok(StaticDb.Notes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id}")]
        //https://localhost:5001/api/notes/1
        public ActionResult<Note> GetById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("ID must be a positive integer");
                }
                if (id > StaticDb.Notes.Count)
                {
                    return NotFound($"There is no resource on index {id}");
                }
                return Ok(StaticDb.Notes[id]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("queryString")]
        //http://localhost:5001/api/notes/queryString?id=1
        public ActionResult<Note> GetByIdQueryString([FromQuery] int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("ID is required");
                }
                if (id < 0)
                {
                    return BadRequest("ID must be a positive integer");
                }
                if (id >= StaticDb.Notes.Count)
                {
                    return NotFound($"There is no resource on index {id}");
                }
                return Ok(StaticDb.Notes[id.Value]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{text:alpha}/priority/{priority:int}")] //alpha means string, priority is an integer
        //http://localhost:5001/api/notes/gym/priority/2
        public ActionResult<List<Note>> FilterNotes(string text, int priority)
        {
            try
            {

                if (string.IsNullOrEmpty(text) || priority <= 0)
                {
                    return BadRequest("Text must be provided and priority must be a positive integer");
                }
                if (priority > 3)
                {
                    return BadRequest("Priority must be between 1 and 3");
                }
                var notes = StaticDb.Notes.Where(n => n.Text.Contains(text) && (int)n.Priority == priority).ToList();
                if (notes.Count == 0)
                {
                    return NotFound($"No notes found with text '{text}' and priority '{priority}'");
                }
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        // POST: api/notes
        public IActionResult Post(Note note)
        {
            try
            {
                if (string.IsNullOrEmpty(note.Text))
                {
                    return BadRequest("Note text is required");
                }
                if (note.Tags == null || note.Tags.Count == 0)
                {
                    return BadRequest("At least one tag is required");
                }
                StaticDb.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, note);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("UserAgent")]
        public IActionResult GetUserAgent(
            [FromHeader(Name = "User-Agent")] string userAgent,
            [FromHeader(Name = "my-token")] string myToken
            )
        {
            List<string> headers = [userAgent, myToken];

            return Ok(headers);
        }    
    
    }

}
