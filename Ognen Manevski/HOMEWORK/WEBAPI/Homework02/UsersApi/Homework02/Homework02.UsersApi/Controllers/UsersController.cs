using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Homework02.UsersApi.Models;

namespace Homework02.UsersApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    /// <summary>
    /// Retrieves all users.
    /// </summary>
    /// <response code="200">Returns the full list of users.</response>
    [HttpGet]
    // GET: api/users
    public ActionResult GetAllUsers()
    {
        return Ok(staticDb.UsersDb);
    }

    /// <summary>
    /// Retrieves a user by their ID.
    /// </summary>
    /// <param name="id">The user ID.</param>
    /// <response code="200">Returns the user when found.</response>
    /// <response code="400">If the provided ID is invalid.</response>
    /// <response code="404">If no user with the specified ID exists.</response>
    [HttpGet("users/{id:int}")]
    // GET: api/users/{id}
    public ActionResult GetUserById(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new
            {
                StatusCode = 400,
                Message = "ID must be greater than 0."
            });
        }

        var user = staticDb.UsersDb.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound(new
            {
                StatusCode = 404,
                Message = $"User with id {id} was not found."
            });
        }

        return Ok(user);
    }

    /// <summary>
    /// Retrieves a user by their first name.
    /// </summary>
    /// <param name="firstName">The user's first name.</param>
    /// <response code="200">Returns the user when found.</response>
    /// <response code="400">If the first name is invalid.</response>
    /// <response code="404">If no user with the specified first name exists.</response>
    [HttpGet("users/{firstName}")]
    // GET: api/users/{id}
    public ActionResult GetUserByFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return BadRequest(new
            {
                StatusCode = 400,
                Message = "A valid User First Name must be provided."
            });
        }

        var user = staticDb.UsersDb.FirstOrDefault(u => u.FirstName == firstName);

        if (user == null)
        {
            return NotFound(new
            {
                StatusCode = 404,
                Message = $"User with First Name [{firstName}] was not found."
            });
        }

        return Ok(user);
    }


    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="newUser">The user data to create.</param>
    /// <response code="201">Returns a success message after creation.</response>
    /// <response code="400">If the user object is invalid or missing required fields.</response>
    /// <response code="500">If an unexpected server error occurs.</response>
    [HttpPost]
    //POST: api/users
    public ActionResult CreateUser([FromBody] User newUser)
    {

        try
        {

            if (
                newUser == null ||
                string.IsNullOrWhiteSpace(newUser.FirstName) ||
                string.IsNullOrWhiteSpace(newUser.LastName))
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Please provide a valid user object with a FirstName and LastName."
                });
            }

            staticDb.AddUser(newUser.FirstName, newUser.LastName);

            return StatusCode(StatusCodes.Status201Created, new
            {
                Message = $"User [{newUser.FirstName} {newUser.LastName}] was created successfully."
            });

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                StatusCode = 500,
                Message = "An error occurred while processing the request.",
                Error = ex.Message
            });
        }
    }


}
