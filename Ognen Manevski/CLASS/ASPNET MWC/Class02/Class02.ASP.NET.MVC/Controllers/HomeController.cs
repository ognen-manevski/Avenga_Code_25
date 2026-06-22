using Class02.ASP.NET.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Class02.ASP.NET.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //methods below are called ACTIONS

    // [HttpGet] -> this is the default for all actions, so we can omit it
    public IActionResult Index() // localhost:port/home/index
                                 //^domain:port/controllerName/actionName/queryString - or parameters
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return RedirectToAction("Index"); // redirect to another action in the same controller (home/index)
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
