namespace TaxiManager5000.Domain.Models;
using TaxiManager5000.Domain.BaseEntity;        

public class Car : BaseEntity
{
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public DateTime LicensePlateExpieryDate { get; set; }
    public List<Driver> AssignedDrivers { get; set; }
}
