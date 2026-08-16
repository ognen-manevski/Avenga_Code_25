using Homework03.BooksApi.Data;
using Homework03.BooksApi.Models;

using Microsoft.AspNetCore.Mvc;

namespace Homework03.BooksApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{

    //Implement a GET endpoint that returns all books.
    [HttpGet]
    //https://localhost:1234/api/books
    public ActionResult GetAllBooks()
    {
        try
        {
            return Ok(StaticDb.Books);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    //Implement a GET endpoint that returns a single book by its index using a query parameter.
    [HttpGet("index")]
    //https://localhost:1234/api/books/index?index=2
    public ActionResult GetBookByIndex([FromQuery] int index)
    {
        try
        {
            if (index < 0)
            {
                return BadRequest("Index must be a positive number");
            }
            if (index >= StaticDb.Books.Count)
            {
                return NotFound($"There is no resource on index {index}");
            }
            return Ok(StaticDb.Books[index]);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    //Implement a GET endpoint that filters books by author and title using query parameters.
    [HttpGet("search")]
    //https://localhost:1234/api/books/search?author=F.%20Scott%20Fitzgerald&title=The%20Great%20Gatsby
    public ActionResult GetBookByAuthorAndTitle([FromQuery] string author, [FromQuery] string title)
    {
        try
        {
            if (author == null || title == null)
            {
                return BadRequest("Author and Title are required parameters");
            }

            var filteredBook = StaticDb.Books.FirstOrDefault(b => b.Author == author && b.Title == title);

            if (filteredBook == null)
            {
                return NotFound($"No book found with Author '{author}' and Title '{title}'");
            }

            return Ok(filteredBook);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    //Implement a POST endpoint that accepts a Book object from the request body using the [FromBody] attribute and adds it to the list.
    [HttpPost("addSingle")]
    //https://localhost:1234/api/books/addSingle
    public IActionResult AddBook([FromBody] Book book)
    {
        try
        {
            if(book == null)
            {
                return BadRequest("Book object must be provided");
            }
            if(string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
            {
                return BadRequest("Book title and author must be provided in the book object");
            }

            StaticDb.AddBook(book);
            return StatusCode(StatusCodes.Status201Created, book);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    //Implement a POST endpoint that accepts a list of Book objects from the request body and returns only their titles as a List<string>.
    [HttpPost("addMultiple")]
    //https://localhost:1234/api/books/addMultiple
    public ActionResult GetBookTitles([FromBody] List<Book> books)
    {
        try
        {
            foreach (var book in books)
            {
                if (book == null || string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("Each book must have a title and an author. None were added.");
                }
            }

            foreach (var book in books)
            {
                StaticDb.AddBook(book);
            }

            var titlesAdded = books.Select(b => b.Title).ToList(); //List<T> where T is string
            return StatusCode(StatusCodes.Status201Created, titlesAdded);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }




}
