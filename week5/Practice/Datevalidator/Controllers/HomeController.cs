using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoWithModel.Models;

namespace DojoWithModel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<Survey> AllSongs { get; set; } = new();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateDojo(Survey newSurvey)
    {
        if (ModelState.IsValid)
        {
            AllSongs.Add(newSurvey);
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
