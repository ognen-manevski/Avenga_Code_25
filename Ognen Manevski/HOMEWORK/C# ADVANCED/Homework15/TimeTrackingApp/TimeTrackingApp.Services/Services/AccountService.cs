using TimeTrackingApp.DataAccess.Repositories;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Helpers;
using TimeTrackingApp.Helpers.Results;
using TimeTrackingApp.Services.Interfaces;
using TimeTrackingApp.Services.Results;

namespace TimeTrackingApp.Services.Services;

public class AccountService : IAccountService
{
    private readonly UserRepository _userRepository;

    public AccountService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //===============================
    //PASSWORD
    //===============================
    public ServiceResult ChangePassword(User user, string newPassword)
    {

        ValidationResult validationResult = ValidationHelper.ValidatePassword(newPassword);
        if (!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.ErrorMessage);
        }

        user.Password = PasswordHelper.HashPassword(newPassword);
        _userRepository.Update(user);

        return new ServiceResult(true, "Password changed successfully!");
    }

    //===============================
    // FIRSTNAME / LASTNAME
    //===============================
    public ServiceResult ChangeFirstName(User user, string newFirstName)
    {

        ValidationResult validationResult = ValidationHelper.ValidateName(newFirstName);
        if (!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.ErrorMessage);
        }


        user.FirstName = newFirstName;
        _userRepository.Update(user);

        return new ServiceResult(true, "First name changed successfully!");
    }

    public ServiceResult ChangeLastName(User user, string newLastName)
    {

        ValidationResult validationResult = ValidationHelper.ValidateName(newLastName);
        if (!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.ErrorMessage);
        }


        user.LastName = newLastName;
        _userRepository.Update(user);

        return new ServiceResult(true, "Last name changed successfully!");
    }


    //===============================
    //ACCOUNT STATUS
    //===============================

    //Not sure what deactivating the account means in the task?

    //if it should be HIDDEN but not deleted:
    public ServiceResult DeactivateAccount(User user)
    {
        user.IsActive = false;
        _userRepository.Update(user);

        return new ServiceResult(true, "Account has been deactivated. You can reactivate it by logging in again.");
    }

    public ServiceResult ReactivateAccount(User user)
    {
        user.IsActive = true;
        _userRepository.Update(user);

        return new ServiceResult(true, "Account has been reactivated successfully!");
    }

    //if the account should be DELETED instead:
}
