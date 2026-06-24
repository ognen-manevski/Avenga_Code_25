namespace TimeTrackingApp.Domain.Enums;

public enum LoginResult
{
    Success = 1,
    InvalidCredentials,
    AccountDeactivated,
    AccountLocked
}