using Class06.DatabaseFirstDemo.Domain.Context;
using Class06.DatabaseFirstDemo.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Class06.DatabaseFirstDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{

    private readonly AppDbContext _context;

    public TodosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Todo>> GetAll()
    {
        List<Todo> todos = _context.Todos
            .Include(t => t.Category)
            .Include(t => t.Status)
            .ToList();
        return Ok(todos);
    }

}
