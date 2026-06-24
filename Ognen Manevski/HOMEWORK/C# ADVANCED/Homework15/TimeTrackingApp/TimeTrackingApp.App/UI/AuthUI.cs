using TimeTrackingApp.Domain.Enums;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.App.UI.Enums;
using TimeTrackingApp.Helpers;
using TimeTrackingApp.Services.Interfaces;
using TimeTrackingApp.Services.Results;

namespace TimeTrackingApp.App.UI;

public class AuthUI
{
    private readonly IAuthService _authService;
    private readonly IActivityService _activityService;
    private readonly IStatisticsService _statisticsService;
    private readonly IAccountService _accountService;

    public AuthUI(IAuthService authService, IActivityService activityService, IStatisticsService statisticsService, IAccountService accountService)
    {
        _authService = authService;
        _activityService = activityService;
        _statisticsService = statisticsService;
        _accountService = accountService;
    }

    public void Run()
    {
        while (true)
        {
            User? user = ShowLoginMenu();

            if (user == null)
            {
                break;
            }

            //show main menu
            MainMenuUI mainMenuUI = new MainMenuUI(user, _activityService, _statisticsService, _accountService);

            bool logout = mainMenuUI.Show();

            if (!logout)
            {
                break;
            }
        }
    }


    //============================
    // LOGIN MENU
    //============================

    private User? ShowLoginMenu()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.PrintAppName();

            ConsoleHelper.PrintHeader("WELCOME TO THE TIME TRACKING APP!");

            var options = new List<string>
            {
                "Login",
                "Register",
                "Exit"
            };

            ConsoleHelper.PrintMenu("Please Login or Register", options);
            LoginMenuOption choice = (LoginMenuOption)ConsoleHelper.GetMenuChoice(options.Count);

            switch (choice)
            {
                case LoginMenuOption.Login:
                    var loginResult = ShowLoginForm();
                    if (loginResult != null)
                    {
                        return loginResult;
                    }
                    break;
                case LoginMenuOption.Register:
                    ShowRegisterForm();
                    break;
                case LoginMenuOption.Exit:
                    return null;
            }
        }
    }


    //============================
    // Login FORM
    //============================

    private User? ShowLoginForm()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();

        ConsoleHelper.PrintHeader("LOGIN");
        ConsoleHelper.PrintInColor("Hint: Username: bob123 | Password: Bob123", ConsoleColor.DarkGray);
        Console.WriteLine();

        string username = ConsoleHelper.GetValidatedStringInput("Username: ", ValidationHelper.ValidateUsername);
        string password = ConsoleHelper.GetValidatedPasswordInput("Password: ", ValidationHelper.ValidatePassword);

        // Attempt login

        AuthResult authResult = _authService.Login(username, password);

        switch (authResult.LoginResult)
        {
            case LoginResult.Success:

                ConsoleHelper.PrintSuccess("Login successful!");
                ConsoleHelper.PressAnyKeyToContinue();
                return authResult.User;

            case LoginResult.AccountLocked:

                ConsoleHelper.PrintError("Maximum failed login attempts reached.");
                ConsoleHelper.PrintError("Application will now close for security reasons.");
                ConsoleHelper.PressAnyKeyToContinue();

                Environment.Exit(0);
                return null;

            case LoginResult.AccountDeactivated:

                ConsoleHelper.PrintWarning("Your account is deactivated.");

                if (ConsoleHelper.GetConfirmation("Do you want to reactivate it? (y/n): "))
                {
                    ServiceResult reactivateResult = _accountService.ReactivateAccount(authResult.User!);

                    if (reactivateResult.Success)
                    {
                        ConsoleHelper.PrintSuccess(reactivateResult.Message);
                        ConsoleHelper.PressAnyKeyToContinue();
                        return authResult.User;
                    }
                }

                ConsoleHelper.PrintInfo("Login cancelled.");
                ConsoleHelper.PressAnyKeyToContinue();
                return null;

            case LoginResult.InvalidCredentials:

                // Invalid credentials

                ConsoleHelper.PrintError("Invalid username or password.");
                ConsoleHelper.PrintWarning($"Failed attempts: {_authService.FailedAttempts}/3");
                ConsoleHelper.PrintWarning($"Remaining attempts: {_authService.RemainingAttempts}");
                ConsoleHelper.PressAnyKeyToContinue();

                return null;

            default:

                ConsoleHelper.PrintError("An unexpected error occurred.");
                ConsoleHelper.PressAnyKeyToContinue();

                return null;
        }
    }

    private void ShowRegisterForm()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("REGISTER NEW ACCOUNT");

        // Collect user information
        string firstName = ConsoleHelper.GetValidatedStringInput("First Name: ", ValidationHelper.ValidateName);
        string lastName = ConsoleHelper.GetValidatedStringInput("Last Name: ", ValidationHelper.ValidateName);
        int age = ConsoleHelper.GetValidatedIntInput("Age: ", ValidationHelper.ValidateAge);
        string username = ConsoleHelper.GetValidatedStringInput("Username: ", ValidationHelper.ValidateUsername);
        string password = ConsoleHelper.GetValidatedPasswordInput("Password: ", ValidationHelper.ValidatePassword);

        // Create user object
        var user = new User(firstName, lastName, age, username, password);

        // Attempt registration
        RegistrationResult registrationResult = _authService.Register(user);

        if (registrationResult.Success)
        {
            ConsoleHelper.PrintSuccess(registrationResult.Message);
        }
        else
        {
            ConsoleHelper.PrintError(registrationResult.Message);
        }

        ConsoleHelper.PressAnyKeyToContinue();
    }
}
