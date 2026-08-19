namespace NotesApp.Services.CustomExceptions;

public class UserNotFoundException
{
    public string UserMessage { get; set; }
    public string DeFaultMessage { get; } = "User not found";
    public UserNotFoundException(string message)
    {
        UserMessage = message ?? DeFaultMessage;
    }
}
