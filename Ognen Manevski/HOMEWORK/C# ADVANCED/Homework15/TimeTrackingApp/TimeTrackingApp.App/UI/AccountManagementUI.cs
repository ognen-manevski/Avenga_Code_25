using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.App.UI.Enums;
using TimeTrackingApp.Helpers;
using TimeTrackingApp.Services.Interfaces;
using TimeTrackingApp.Services.Results;

namespace TimeTrackingApp.App.UI;

public class AccountManagementUI
{
    private readonly User _currentUser;
    private readonly IAccountService _accountService;

    public AccountManagementUI(User currentUser, IAccountService accountService)
    {
        _currentUser = currentUser;
        _accountService = accountService;
    }

    public bool Show()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.PrintAppName();
            ConsoleHelper.PrintHeader("ACCOUNT MANAGEMENT");

            Console.WriteLine();
            ConsoleHelper.PrintInfo($"Current Account: {_currentUser.FirstName} {_currentUser.LastName}");
            ConsoleHelper.PrintInfo($"Username: {_currentUser.Username}");
            Console.WriteLine();

            var options = new List<string>
            {
                "Change Password",
                "Change First Name",
                "Change Last Name",
                "Deactivate Account",
                "Back to Main Menu"
            };

            ConsoleHelper.PrintMenu("SELECT AN OPTION", options);
            AccountMenuOption choice = (AccountMenuOption)ConsoleHelper.GetMenuChoice(options.Count);

            switch (choice)
            {
                case AccountMenuOption.ChangePassword:
                    ChangePassword();
                    break;
                case AccountMenuOption.ChangeFirstName:
                    ChangeFirstName();
                    break;
                case AccountMenuOption.ChangeLastName:
                    ChangeLastName();
                    break;
                case AccountMenuOption.DeactivateAccount:
                    bool accountActive = DeactivateAccount();
                    if (!accountActive)
                    {
                        return false;
                    }
                    break;
                case AccountMenuOption.BackToMainMenu:
                    return true;
            }
        }
    }

    private void ChangePassword()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("CHANGE PASSWORD");

        string newPassword = ConsoleHelper.GetValidatedPasswordInput("Enter new password: ", ValidationHelper.ValidatePassword);

        ServiceResult result = _accountService.ChangePassword(_currentUser, newPassword);

        if (result.Success)
        {
            ConsoleHelper.PrintSuccess(result.Message);
        }
        else
        {
            ConsoleHelper.PrintError(result.Message);
        }

        ConsoleHelper.PressAnyKeyToContinue();
    }

    private void ChangeFirstName()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("CHANGE FIRST NAME");

        ConsoleHelper.PrintInfo($"Current First Name: {_currentUser.FirstName}");
        string newFirstName = ConsoleHelper.GetValidatedStringInput("Enter new first name: ", ValidationHelper.ValidateName);

        ServiceResult result = _accountService.ChangeFirstName(_currentUser, newFirstName);

        if (result.Success)
        {
            ConsoleHelper.PrintSuccess(result.Message);
        }
        else
        {
            ConsoleHelper.PrintError(result.Message);
        }

        ConsoleHelper.PressAnyKeyToContinue();
    }

    private void ChangeLastName()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("CHANGE LAST NAME");

        ConsoleHelper.PrintInfo($"Current Last Name: {_currentUser.LastName}");
        string newLastName = ConsoleHelper.GetValidatedStringInput("Enter new last name: ", ValidationHelper.ValidateName);

        ServiceResult result = _accountService.ChangeLastName(_currentUser, newLastName);

        if (result.Success)
        {
            ConsoleHelper.PrintSuccess(result.Message);
        }
        else
        {
            ConsoleHelper.PrintError(result.Message);
        }

        ConsoleHelper.PressAnyKeyToContinue();
    }

    private bool DeactivateAccount()
    {
        Console.Clear();
        ConsoleHelper.PrintAppName();
        ConsoleHelper.PrintHeader("DEACTIVATE ACCOUNT");

        ConsoleHelper.PrintWarning("Are you sure you want to deactivate your account?");
        ConsoleHelper.PrintWarning("You can reactivate it by logging in again.");
        Console.WriteLine();

        if (ConsoleHelper.GetConfirmation("Confirm deactivation (y/n): "))
        {
            ServiceResult result = _accountService.DeactivateAccount(_currentUser);

            if (result.Success)
            {
                ConsoleHelper.PrintSuccess(result.Message);
                ConsoleHelper.PressAnyKeyToContinue();
                return false;
            }
            else
            {
                ConsoleHelper.PrintError(result.Message);
                ConsoleHelper.PressAnyKeyToContinue();
                return true;
            }
        }
        else
        {
            ConsoleHelper.PrintInfo("Account deactivation cancelled.");
            ConsoleHelper.PressAnyKeyToContinue();
            return true;
        }
    }
}
