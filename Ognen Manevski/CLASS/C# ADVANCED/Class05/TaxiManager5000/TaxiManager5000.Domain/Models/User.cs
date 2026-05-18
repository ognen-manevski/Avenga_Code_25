
namespace TaxiManager5000.Domain.Models;

using TaxiManager5000.Domain.Enums;
using TaxiManager5000.Domain.BaseEntity;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
