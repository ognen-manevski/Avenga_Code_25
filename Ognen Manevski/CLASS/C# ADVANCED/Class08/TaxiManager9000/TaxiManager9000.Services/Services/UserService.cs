using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.DataAccess.Interfaces;

namespace TaxiManager9000.Services.Services;

public class UserService : ServiceBase<User>, IUserService
{
    private IGenericDb<User> _db;

    public int ChooseMenu<T>(List<T> items)
    {
        throw new NotImplementedException();
    }

}
