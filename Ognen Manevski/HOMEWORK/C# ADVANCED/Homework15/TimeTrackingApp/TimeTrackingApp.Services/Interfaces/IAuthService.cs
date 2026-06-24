using TimeTrackingApp.Domain.Enums;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Helpers.Results;
using TimeTrackingApp.Services.Results;

namespace TimeTrackingApp.Services.Interfaces;

public interface IAuthService
{

    int FailedAttempts { get; }
    int RemainingAttempts { get; }
    bool IsLockedOut { get; }


    RegistrationResult Register(User user);
    ValidationResult ValidateRegistration(User user);
    AuthResult Login(string username, string password);
}
