using TimeTrackingApp.App.UI;
using TimeTrackingApp.DataAccess.Repositories;
using TimeTrackingApp.Helpers;
using TimeTrackingApp.Services.Services;

Console.Title = "Time Tracking App";
ConsoleHelper.PrintAppName();

// INITIALIZATION

//repositories
var userRepository = new UserRepository();
var activityRepository = new ActivityRepository();

//services
var authService = new AuthService(userRepository);
var activityService = new ActivityService(activityRepository);
var statisticsService = new StatisticsService(activityRepository);
var accountService = new AccountService(userRepository);

//auth
var authUI = new AuthUI(authService, activityService, statisticsService, accountService);

//RUN
authUI.Run();
