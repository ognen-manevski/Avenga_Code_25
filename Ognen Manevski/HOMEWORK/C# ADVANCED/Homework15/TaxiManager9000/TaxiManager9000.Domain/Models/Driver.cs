namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.BaseEntity;

public class Driver : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Shift Shift { get; set; }
    public Car? Car { get; set; }
    public string License { get; set; } = string.Empty;
    public DateTime LicenseExpieryDate { get; set; }
    public DateTime DateTime { get; }
    public Driver() { }
    public Driver(string firstName, string lastName, Shift shift, Car car, string license, DateTime expieryDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Shift = shift;
        Car = car;
        License = license;
        LicenseExpieryDate = expieryDate;
    }
    public override string GetInfo()
    {
        return $"Driver {FirstName} {LastName} with license {License}!";
    }
    public ExpieryStatus IsLicenseExpired()
    {
        if (DateTime.Today >= LicenseExpieryDate) return ExpieryStatus.Expired;
        else if (DateTime.Today.AddMonths(3) >= LicenseExpieryDate) return ExpieryStatus.Warning;
        else return ExpieryStatus.Valid;
    }
}
