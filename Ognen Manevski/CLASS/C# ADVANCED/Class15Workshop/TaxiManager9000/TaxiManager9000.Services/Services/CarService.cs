using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class CarService : ServiceBase<Car>, ICarService
    {
        public bool IsAvailableCar(Car car) =>
    car.IsLicenseExpired() == ExpieryStatus.Expired || car.AssignedDrivers.Count == 3 ? false : true;
    }
}
