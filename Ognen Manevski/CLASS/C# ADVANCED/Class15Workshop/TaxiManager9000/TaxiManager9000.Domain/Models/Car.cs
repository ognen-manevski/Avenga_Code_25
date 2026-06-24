namespace TaxiManager9000.Domain.Models;

using TaxiManager9000.Domain.BaseEntity;
using TaxiManager9000.Domain.Enums;

public class Car : BaseEntity
{
    public string Model { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public DateTime LicensePlateExpieryDate { get; set; }
    public List<Driver> AssignedDrivers { get; set; } = new();
    public Car() { }
    public Car(string model, string licensePlate, DateTime experyDate)
    {
        Model = model;
        LicensePlate = licensePlate;
        LicensePlateExpieryDate = experyDate;
        AssignedDrivers = new List<Driver>();
    }
    public override string GetInfo()
    {
        return $"Car model {Model}";
    }
    public ExpieryStatus IsLicenseExpired()
    {
        if (DateTime.Today >= LicensePlateExpieryDate) return ExpieryStatus.Expired;
        else if (DateTime.Today.AddMonths(3) >= LicensePlateExpieryDate) return ExpieryStatus.Warning;
        else return ExpieryStatus.Valid;
    }
}
