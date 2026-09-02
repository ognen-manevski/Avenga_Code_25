using Microsoft.EntityFrameworkCore;
using NotesApp.DataAccess.Data;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Enums;
using NotesApp.Domain.Models;
using NotesApp.Dtos;

namespace NotesApp.DataAccess.Implementations.EntityFramework;

public class NoteRepository : INoteRepository
{
    private readonly NotesAppDbContext _context;

    public NoteRepository(NotesAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Note>> GetAllAsync()
    {
        var notes = _context.Notes
            .AsNoTracking() //mandatory for read-only queries to improve performance!
                            //dont use with SaveChangesAsync, UpdateAsync, DeleteAsync, AddAsync, etc.
            .Include(note => note.Tags)
            .Include(note => note.User)
            .AsQueryable();

        // ToListAsync, FirstOrDefault, FirstOrDefaultAsync, SingleOrDefault, SingleOrDefaultAsync, ToList, ToArray, ToDictionary, ToLookup, Count, LongCount, Any, All, Contains, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault
        //for pagination , you can use Skip and Take methods, for example:
        // var pagedNotes = notes.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        // You can use any of the above methods to execute the query and retrieve the results.

        return await notes.ToListAsync();
    }

    public async Task<Note?> GetByIdAsync(int id)
    {
        return await _context.Notes
            .Include(note => note.Tags)
            .Include(note => note.User)
            .FirstOrDefaultAsync(note => note.Id == id);
    }

    public async Task<List<Note>> GetByIdsAsync(List<int> ids)
    {
        return await _context.Notes
            .Include(note => note.Tags)
            .Include(note => note.User)
            .Where(note => ids.Contains(note.Id))
            .ToListAsync();
    }

    public async Task AddAsync(Note entity)
    {
        _context.Notes.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Note entity)
    {
        //_context.Notes.Update(entity); // this is needed if the entity is not tracked by the context
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Note entity)
    {
        _context.Notes.Remove(entity);
        await _context.SaveChangesAsync();
    }


    //EXAMPLE OF A CUSTOM QUERY METHOD
    public async Task<List<Note>> GetAllByPriorityAsync(Priority? priority = null)
    {

        //1) Build the query using LINQ
        IQueryable<Note> query = _context.Notes;

        //2) Apply the filter if priority is provided
        if (priority.HasValue)
        {
            query = query.Where(note => note.Priority == priority);
        }

        //3) Project the query to NoteDto
        //very important to use Select to project the query to NoteDto
        //to save on memory and performance, because we don't need to load the entire Note entity
        //with all its properties and navigation properties
        var noteDtoQuery = query.Select(note => new NoteDto
        {
            Id = note.Id,
            Priority = note.Priority,
            Text = note.Text,
            UserFullName = note.User == null ? "unknown" : $"{note.User.FirstName} {note.User.LastName}",
            //handling the tags because its a collection
            Tags = note.Tags.Select(tag => new TagDto
            {
                Id = tag.Id,
                Name = tag.Name,
                Color = tag.Color
            }).ToList(),
            //continuing with the rest of the properties
            CreatedDate = note.CreatedDate,
            UpdatedDate = note.UpdatedDate
        });

        return await query.ToListAsync();
    }

}
