using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecentMemory.Models;

namespace RecentMemory.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }
}
 /* Adicionando */