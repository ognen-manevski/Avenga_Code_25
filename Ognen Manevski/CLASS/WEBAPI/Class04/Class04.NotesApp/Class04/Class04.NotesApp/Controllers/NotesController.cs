using Class04.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Class04.NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;


    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }





}
