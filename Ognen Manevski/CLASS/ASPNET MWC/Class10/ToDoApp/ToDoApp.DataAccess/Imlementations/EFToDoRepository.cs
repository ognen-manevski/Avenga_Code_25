
using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Imlementations;

public class EFToDoRepository : IRepository<ToDo>
{
    private readonly ToDoAppDbContext _context;

    public EFToDoRepository(ToDoAppDbContext context)
    {
        _context = context;
    }

    public void Create(ToDo entity)
    {
        _context.ToDo.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var todo = GetById(id);
        if (todo != null)
        {
            _context.ToDo.Remove(todo);
            _context.SaveChanges();
        }
    }


    public List<ToDo> GetAll()
    {
        var toDos = _context.ToDo
            .Include(t => t.Status)
            .Include(t => t.Category)
            .ToList();
        return toDos;
    }

    public ToDo GetById(int id)
    {
        var toDo = _context.ToDo
            .Include(t => t.Status)
            .Include(t => t.Category)
            .FirstOrDefault(t => t.Id == id);
        return toDo;
    }

    public List<ToDo> GetByName(string name)
    {
        var toDos = _context.ToDo
        .Include(t => t.Status)
        .Where(t => t.Name.Contains(name))
        .ToList();
        return toDos;

    }

    public void Update(ToDo entity)
    {
        _context.ToDo.Update(entity);
        _context.SaveChanges();
    }


}
