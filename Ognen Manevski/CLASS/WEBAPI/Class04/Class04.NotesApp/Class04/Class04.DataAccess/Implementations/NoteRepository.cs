using Class04.DataAccess.Interfaces;
using Class04.Domain.Models;
using NotesApp.DataAccess.Data;

namespace Class04.DataAccess.Implementations;

public class NoteRepository : INoteRepository
{
    public void Add(Note entity)
    {
        entity.Id = StaticDb.NextNoteId();
        StaticDb.Notes.Add(entity);
    }

    public void Delete(Note entity)
    {

        StaticDb.Notes.Remove(entity);
    }

    public List<Note> GetAll()
    {
        return StaticDb.Notes.ToList();
    }

    public Note? GetById(int id)
    {
        return StaticDb.Notes.FirstOrDefault(n=> n.Id == id);
    }

    public void Update(Note entity)
    {
        int index = StaticDb.Notes.FindIndex(n => n.Id == entity.Id);
        if (index >= 0)
        {
            StaticDb.Notes[index] = entity;
        }
    }
}
