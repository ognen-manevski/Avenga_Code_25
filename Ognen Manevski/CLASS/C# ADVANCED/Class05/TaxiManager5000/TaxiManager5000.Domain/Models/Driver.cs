
namespace TaxiManager5000.Domain.Models;

using TaxiManager5000.Domain.Enums;
using TaxiManager5000.Domain.BaseEntity;

public class Driver : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Shift Shift { get; set; }
    public Car Car { get; set; }
    public string License { get; set; }
    public DateTime LicenseExpieryDate { get; set; }
}
