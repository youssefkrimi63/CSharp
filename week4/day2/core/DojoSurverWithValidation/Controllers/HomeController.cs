using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurverWithValidation.Models;

namespace DojoSurverWithValidation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<Survey> Users { get; set; } = new();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateSurvey(Survey newSurvey)
    {
        if (ModelState.IsValid)
        {
            Users.Add(newSurvey);
            return View("Privacy", newSurvey);
        }
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class Survey
{
}