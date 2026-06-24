using TimeTrackingApp.Domain.Enums;
using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.Services.Results;

public class AuthResult : ServiceResult
{
    public LoginResult LoginResult { get; set; }
    public User? User { get; set; }

    public AuthResult() { }

    public AuthResult(bool success, LoginResult loginResult, User? user)
    {
        Success = success;
        LoginResult = loginResult;
        User = user;
    }
}
