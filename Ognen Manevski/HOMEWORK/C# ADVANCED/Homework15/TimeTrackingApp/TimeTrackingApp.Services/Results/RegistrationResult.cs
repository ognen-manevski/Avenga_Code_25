using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.Services.Results;

public class RegistrationResult : ServiceResult
{
    public User? User { get; set; }

    public RegistrationResult() { }

    public RegistrationResult(bool success, string message, User? user)
        : base(success, message)
    {
        User = user;
    }
}
