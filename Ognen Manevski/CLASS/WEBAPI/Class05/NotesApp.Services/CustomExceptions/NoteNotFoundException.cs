namespace NotesApp.Services.CustomExceptions;

public class NoteNotFoundException : Exception
{
    public string NoteMessage { get; set; }
    public string DeFaultMessage { get; } = "Note not found";
    public NoteNotFoundException(string message)
    {
        NoteMessage = message ?? DeFaultMessage;
    }
}
