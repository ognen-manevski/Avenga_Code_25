using NotesApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Dtos;
using NotesApp.Services.CustomExceptions;
using Microsoft.AspNetCore.Authorization;

namespace NotesApp.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
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

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {

            LoginResponseDto loginResponse = await _authService.LoginAsync(loginDto);

            return Ok(loginResponse);
        }
        catch(InvalidCredentialsException ex)
        {
            return Problem(
                detail: ex.Message,
                statusCode: StatusCodes.Status401Unauthorized
                );
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
