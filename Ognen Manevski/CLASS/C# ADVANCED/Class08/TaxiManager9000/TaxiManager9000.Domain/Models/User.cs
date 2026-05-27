namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.BaseEntity;
using TaxiManager9000.Domain.Enums;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; }
}
