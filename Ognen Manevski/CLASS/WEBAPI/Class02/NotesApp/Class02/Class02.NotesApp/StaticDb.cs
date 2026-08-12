namespace Class02.NotesApp;

public static class StaticDb
{
    public static List<string> SimpleNotes { get; set; } = new List<string>
    {
        "Do the homework",
        "Clean the room",
        "Buy groceries",
        "Call mom"
    };
}
