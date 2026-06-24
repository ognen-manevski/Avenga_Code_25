using TaxiManager9000.Domain.BaseEntity;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;

namespace TaxiManager9000.Helpers
{
    public static class ConsoleHelper
    {
        public static void PrintInColor(string value, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void PrintTitle(string value)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadLine();
        }

        public static string? GetInput(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

        public static void NoItemsMessage<T>() => Console.WriteLine($"No {typeof(T).Name}s available");

        public static void Separator() => Console.WriteLine("---------------------------");

        public static void Print<T>(this List<T> list) where T : BaseEntity
        {
            if (list.Count == 0) NoItemsMessage<T>();
            else foreach (var item in list) Console.WriteLine(item.GetInfo());
            Console.ReadLine();
        }
        private static readonly Dictionary<ExpieryStatus, ConsoleColor> StatusColorMap = new Dictionary<ExpieryStatus, ConsoleColor>()
        {
            {ExpieryStatus.Valid, ConsoleColor.Green },
            {ExpieryStatus.Warning, ConsoleColor.Yellow },
            {ExpieryStatus.Expired, ConsoleColor.Red }
        };
        public static void PrintStatus(this List<Car> list)
        {
            if (list.Count == 0) NoItemsMessage<Car>();
            else foreach (var car in list)
                {
                    ExpieryStatus expieryStatus = car.IsLicenseExpired();
                    PrintInColor($"[{expieryStatus}]) ", StatusColorMap[expieryStatus]);
                    Console.WriteLine($"Car Id: {car.Id} - Plate: {car.LicensePlate} with expiery date: {car.LicensePlateExpieryDate}");
                }

            Console.ReadLine();
        }

        public static void PrintStatus(this List<Driver> list)
        {
            if (list.Count == 0) NoItemsMessage<Car>();
            else foreach (var driver in list)
                {
                    ExpieryStatus expieryStatus = driver.IsLicenseExpired();
                    PrintInColor($"[{expieryStatus}]) ", StatusColorMap[expieryStatus]);
                    Console.WriteLine($"Driver: {driver.FirstName} with license {driver.License} with expiery date: {driver.LicenseExpieryDate}");
                }

            Console.ReadLine();
        }
    }
}
