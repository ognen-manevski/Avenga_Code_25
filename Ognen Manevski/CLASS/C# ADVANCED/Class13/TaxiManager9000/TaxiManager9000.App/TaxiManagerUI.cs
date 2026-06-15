using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.Helpers;
using TaxiManager9000.Services.Enums;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Services.Services;

namespace TaxiManager9000.App
{
    internal class TaxiManagerUI
    {
        private readonly IUIService _uiService;
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly IDriverService _driverService;

        public TaxiManagerUI()
        {
            _uiService = new UIService();
            _userService = new UserService();
            _carService = new CarService();
            _driverService = new DriverService();

            SeedData();
        }

        public void InitApp()
        {
            while (true)
            {
                Console.Clear();
                #region Login Menu

                if (_userService.CurrentUser is null)
                {
                    try
                    {
                        ConsoleHelper.PrintTitle("\n\t*** Taxi Manager 9000 ***\n");
                        //int choice = _uiService.ChooseMenu(new List<string> { "Login", "Exit" });
                        int choice = _uiService.ChooseMenu(["Login", "Exit"]);
                        if (choice == -1)
                        {
                            ConsoleHelper.PrintError("Invalid choice! Try again.");
                            continue;
                        }
                        if (choice == 2) break;

                        // Login Menu
                        User inputUser = _uiService.LogInMenu();
                        _userService.LogIn(inputUser.Username, inputUser.Password);
                        ConsoleHelper.PrintSuccess($"Welcome [{_userService.CurrentUser.Role}] {_userService.CurrentUser.Username}!");
                    }
                    catch (Exception ex)
                    {
                        ConsoleHelper.PrintError(ex.ToString());
                        continue;
                    }
                }

                #endregion



                #region Main Menu

                int menuChoiceNumber = _uiService.MainMenu(_userService.CurrentUser.Role);

                if (menuChoiceNumber == -1)
                {
                    ConsoleHelper.PrintError("Invalid choice! Try again.");
                    return;
                }

                MenuChoice mainMenuChoice = _uiService.MenuItems[menuChoiceNumber - 1];

                switch (mainMenuChoice)
                {
                    case MenuChoice.AddNewUser:
                        ConsoleHelper.PrintInColor("Adding a new user...", ConsoleColor.Cyan);

                        string username = ConsoleHelper.GetInput("Enter new username: ");
                        if (!ValidationHelper.ValidateUsername(username))
                        {
                            ConsoleHelper.PrintError("Invalid username! It must be at least 5 characters long and contain only letters and numbers.");
                        }

                        string password = ConsoleHelper.GetInput("Enter new password: ");
                        if (!ValidationHelper.ValidatePassword(password))
                        {
                            ConsoleHelper.PrintError("Invalid password! It must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number.");
                        }

                        int role = _uiService.ChooseMenu(new List<string>()
                        {
                            "Administrator",
                            "Manager",
                            "Maintenance"
                        });

                        try
                        {
                            _userService.CreateNewUser(username, password, (Role)role);

                            ConsoleHelper.PrintSuccess($"User '{username}' created successfully with role '{(Role)role}'!");
                        }
                        catch (Exception ex)
                        {
                            ConsoleHelper.PrintError(ex.Message);
                        }


                        break;
                    case MenuChoice.RemoveExistingUser:
                        ConsoleHelper.PrintInColor(" ========= Remove an existing user...", ConsoleColor.DarkRed);

                        List<User> users = _userService.GetAll().Where(x=>x.Id != _userService.CurrentUser.Id).ToList();

                        int menuChoice = _uiService.ChooseEntitiesMenu(users);

                        if (menuChoice == -1) continue;

                        _userService.Remove(users[menuChoice - 1].Id);

                        break;

                    case MenuChoice.ListAllDrivers:
                        ConsoleHelper.PrintInColor("Listing all drivers...", ConsoleColor.Cyan);
                        break;
                    case MenuChoice.ListAllCars:
                        ConsoleHelper.PrintInColor("Listing all cars...", ConsoleColor.Cyan);
                        break;
                    case MenuChoice.LicencePlateStatus:
                        ConsoleHelper.PrintInColor("Checking license plate status...", ConsoleColor.Cyan);
                        break;
                    case MenuChoice.DriverManager:
                        ConsoleHelper.PrintInColor("Accessing driver manager...", ConsoleColor.Cyan);
                        break;
                    case MenuChoice.ChangePassword:
                        ConsoleHelper.PrintInColor("Changing password...", ConsoleColor.Cyan);

                        string oldPassword = ConsoleHelper.GetInput("Enter your current password: ");
                        string newPassword = ConsoleHelper.GetInput("Enter your new password: ");

                        if (
                            !ValidationHelper.ValidateStringInput(newPassword) ||
                            !ValidationHelper.ValidateStringInput(oldPassword)
                            )
                        {
                            ConsoleHelper.PrintError("Please enter valid values!");
                        }

                        bool changeSuccess = _userService.ChangePassword(oldPassword, newPassword);

                        if (changeSuccess)
                        {
                            ConsoleHelper.PrintSuccess("Password changed successfully!");
                        }
                        else
                        {
                            ConsoleHelper.PrintError("Failed to change password. Please check your current password and try again.");
                        }
                        break;

                    case MenuChoice.TaxiLicenseStatus:
                        ConsoleHelper.PrintInColor("Checking taxi license status...", ConsoleColor.Cyan);
                        break;
                    case MenuChoice.Exit:
                        ConsoleHelper.PrintInColor("Exiting the application. Goodbye!", ConsoleColor.Yellow);
                        _userService.CurrentUser = null; // Log out the current user
                        continue;
                    default:
                        ConsoleHelper.PrintError("Invalid choice! Try again.");
                        break;
                }

                #endregion

            }

        }
        private void SeedData()
        {
            User administrator = new User("bob123", "bob123", Role.Administrator);
            User manager = new User("JillWayne", "jillawesome1", Role.Manager);
            User maintenances = new User("GregGregsky", "supergreg1", Role.Maintenance);
            List<User> seedUsers = new List<User>() { administrator, manager, maintenances };
            _userService.Seed(seedUsers);

            Car car1 = new Car("Auris (Toyota)", "AFW950", new DateTime(2023, 12, 1));
            Car car2 = new Car("Auris (Toyota)", "CKE480", new DateTime(2021, 10, 15));
            Car car3 = new Car("Transporter (Volkswagen)", "GZDR69", new DateTime(2024, 5, 30));
            Car car4 = new Car("Mondeo (Ford)", "5RIP283", new DateTime(2022, 5, 13));
            Car car5 = new Car("Premier (Peugeot)", "2AR9907", new DateTime(2022, 11, 9));
            Car car6 = new Car("Vito (Mercedes)", "6RND294", new DateTime(2023, 3, 11));
            List<Car> seedCars = new List<Car>() { car1, car2, car3, car4, car5, car6 };
            _carService.Seed(seedCars);

            Driver driver1 = new Driver("Romario", "Walsh", Shift.NoShift, null, "LC12456123", new DateTime(2023, 11, 5));
            Driver driver2 = new Driver("Kathleen", "Rankin", Shift.Morning, car1, "LC54435234", new DateTime(2022, 1, 12));
            Driver driver3 = new Driver("Ashanti", "Mooney", Shift.Evening, car1, "LC65803245", new DateTime(2022, 5, 19));
            Driver driver4 = new Driver("Zakk", "Hook", Shift.Afternoon, car1, "LC20897583", new DateTime(2023, 9, 28));
            Driver driver5 = new Driver("Xavier", "Kelly", Shift.NoShift, null, "LC15636280", new DateTime(2024, 6, 1));
            Driver driver6 = new Driver("Joy", "Shelton", Shift.Evening, car2, "LC47845611", new DateTime(2023, 7, 3));
            Driver driver7 = new Driver("Kristy", "Riddle", Shift.Morning, car3, "LC19006543", new DateTime(2024, 6, 12));
            Driver driver8 = new Driver("Stuart", "Mayer", Shift.Evening, car3, "LC53187767", new DateTime(2023, 10, 10));
            List<Driver> seedDrivers = new List<Driver>() { driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8 };
            _driverService.Seed(seedDrivers);
        }
    }

}
