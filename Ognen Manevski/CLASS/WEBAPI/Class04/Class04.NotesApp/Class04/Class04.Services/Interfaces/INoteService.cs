using Class04.Domain.Enums;
using Class04.Dtos;
namespace Class04.Services.Interfaces;

public interface INoteService
{
    List<NoteDto> GetAllNotes(Priority? priority = null);
}
