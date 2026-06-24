using TimeTrackingApp.Domain.Enums;
using TimeTrackingApp.DataAccess.Repositories;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Helpers;
using TimeTrackingApp.Helpers.Results;
using TimeTrackingApp.Services.Interfaces;
using TimeTrackingApp.Services.Results;

namespace TimeTrackingApp.Services.Services;

public class AuthService : IAuthService
{
    private readonly UserRepository _userRepository;
    private const int MaxLoginAttempts = 3;
    private int _failedAttempts = 0;

    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //==================================
    // PROPERTIES
    //==================================

    public int FailedAttempts => _failedAttempts;
    public int RemainingAttempts => MaxLoginAttempts - _failedAttempts;
    public bool IsLockedOut => _failedAttempts >= MaxLoginAttempts;

    //==================================
    // REGISTER
    //==================================

    public RegistrationResult Register(User user)
    {
        ValidationResult validationResult = ValidateRegistration(user);

        if (!validationResult.IsValid)
        {
            return new RegistrationResult(false, validationResult.ErrorMessage, null);
        }

        var existingUser = _userRepository.GetByUsername(user.Username);
        if (existingUser != null)
        {
            return new RegistrationResult(false, "Username already exists. Please choose a different username.", null);
        }

        user.Password = PasswordHelper.HashPassword(user.Password);
        _userRepository.Add(user);
        return new RegistrationResult(true, "Registration successful! You can now log in.", user);
    }

    public ValidationResult ValidateRegistration(User user)
    {
        ValidationResult firstNameResult = ValidationHelper.ValidateName(user.FirstName);
        if (!firstNameResult.IsValid)
        {
            return new ValidationResult(false, $"First Name: {firstNameResult.ErrorMessage}");
        }

        ValidationResult lastNameResult = ValidationHelper.ValidateName(user.LastName);
        if (!lastNameResult.IsValid)
        {
            return new ValidationResult(false, $"Last Name: {lastNameResult.ErrorMessage}");
        }

        ValidationResult ageResult = ValidationHelper.ValidateAge(user.Age);
        if (!ageResult.IsValid)
        {
            return ageResult;
        }

        ValidationResult usernameResult = ValidationHelper.ValidateUsername(user.Username);
        if (!usernameResult.IsValid)
        {
            return usernameResult;
        }

        ValidationResult passwordResult = ValidationHelper.ValidatePassword(user.Password);
        if (!passwordResult.IsValid)
        {
            return passwordResult;
        }

        return new ValidationResult(true, string.Empty);
    }

    //==================================
    // LOGIN
    //==================================

    public AuthResult Login(string username, string password)
    {
        if (IsLockedOut)
        {
            return new AuthResult(false, LoginResult.AccountLocked, null);
        }

        var user = _userRepository.GetByUsername(username);

        if (user == null || !PasswordHelper.VerifyPassword(password, user.Password))
        {
            _failedAttempts++;
            return new AuthResult(false, LoginResult.InvalidCredentials, null);
        }

        if (!user.IsActive)
        {
            return new AuthResult(false, LoginResult.AccountDeactivated, user);
        }

        _failedAttempts = 0;
        return new AuthResult(true, LoginResult.Success, user);
    }

}
