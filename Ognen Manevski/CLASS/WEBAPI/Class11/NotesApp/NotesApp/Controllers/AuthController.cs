using NotesApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Dtos;
using NotesApp.Services.CustomExceptions;

namespace NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            UserDto userDto = await _authService.RegisterAsync(registerDto);

            return StatusCode(StatusCodes.Status201Created, userDto);
        }
        catch (UserDataException ex)
        {
            return Problem(
                detail: ex.Message,
                statusCode: StatusCodes.Status400BadRequest
                );
        }
        catch (Exception ex)
        {
            return Problem(
                detail: "Internal server error",
                statusCode: StatusCodes.Status500InternalServerError
                );
        }
    }

}
