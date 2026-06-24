using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class DriverService : ServiceBase<Driver>, IDriverService
    {
        public void AssignDriver(Driver driver, Car car)
        {
            driver.Car = car;
            _db.Update(driver);
        }

        public void Unassign(Driver driver)
        {
            driver.Car = null;
            _db.Update(driver);
        }

        public bool IsAvailableDriver(Driver driver) =>
            driver.IsLicenseExpired() == ExpieryStatus.Expired ? false : true;

    }
}
