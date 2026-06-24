using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Services.Results;

namespace TimeTrackingApp.Services.Interfaces;

//Account management

//    Change password
//    Change First and Last name
//    BONUS: Deactivate account

public interface IAccountService
{
    ServiceResult ChangePassword(User user, string newPassword);

    ServiceResult ChangeFirstName(User user, string newFirstName);

    ServiceResult ChangeLastName(User user, string newLastName);

    ServiceResult DeactivateAccount(User user);

    ServiceResult ReactivateAccount(User user);
}
