using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Enums;
using NotesApp.Domain.Models;
using NotesApp.Dtos;
using NotesApp.Mappers;
using NotesApp.Services.CustomExceptions;
using NotesApp.Services.Interfaces;

namespace NotesApp.Services.Implementations;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITagRepository _tagRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }




    public List<NoteDto> GetAllNotes(Priority? priority = null)
    {
        // 1) Get all notes from db
        List<Note> notesDb = _noteRepository.GetAll();

        // Optional filter
        if (priority.HasValue)
        {
            notesDb = notesDb.Where(note => note.Priority == priority).ToList();
        }

        // 2) Map notes from db to dto

        // ===> Mapping explained
        // Note note = new();
        // => Here we use the static mapper method to map the note to a NoteDto
        // NoteDto noteDto = NoteMapper.ToNoteDto(note);
        // => Here we use the extension method (defined by the 'this' keyword) to map the note to a NoteDto (BETTER WAY)
        // NoteDto noteDto = note.ToNoteDto();

        // ==> Way 1 (not recommended)
        //notesDb.Select(note => new NoteDto
        //{
        //    Id = note.Id,
        //    ...
        //});

        // ==> Way 2 (slightly better)
        //List<NoteDto> mappedNotes = notesDb.Select(note => note.ToNoteDto()).ToList();

        // ==> Way 3 (best way)
        List<NoteDto> noteDtos = notesDb.ToNoteDtoList();

        return noteDtos;
    }

    public NoteDto GetNoteById(int id)
    {
        Note? noteDb = _noteRepository.GetById(id);
        if (noteDb == null)
        {
            throw new NoteNotFoundException($"Note with ID {id} was not found.");
        }
        return noteDb.ToNoteDto();
    }

    public NoteDto AddNote(AddNoteDto addNoteDto)
    {
        //validate
        ValidateText(addNoteDto.Text);

        User user = _userRepository.GetById(addNoteDto.UserId);

        if (user is null)
        {
            throw new UserNotFoundException($"User with ID {addNoteDto.UserId} was not found.");
        }

        List<Tag> tags = new List<Tag>();
        foreach (int tagId in addNoteDto.TagIds)
        {
            Tag tag = _tagRepository.GetById(tagId);
            if (tag is null)
            {
                throw new TagNotFoundException($"Tag with ID {tagId} was not found.");
            }
            tags.Add(tag);
        }

    }


    #region Private Helper Methods
    
    private void ValidateText (string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new NoteDataException("Text is a required field.");
        }
        if (text.Length > 100)
        {
            throw new NoteDataException("Text cannot exceed 100 characters.");
        }


    }

    

    #endregion



}
