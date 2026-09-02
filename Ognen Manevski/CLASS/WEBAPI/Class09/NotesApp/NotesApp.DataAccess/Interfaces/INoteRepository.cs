using NotesApp.Domain.Enums;
using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Interfaces;

public interface INoteRepository : IRepository<Note>
{
    Task<List<Note>> GetAllByPriorityAsync(Priority? priority = null);
}
