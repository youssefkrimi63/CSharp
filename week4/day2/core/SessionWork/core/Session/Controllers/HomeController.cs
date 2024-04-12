using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session.Models;
// ! Session Config Part 2
using Microsoft.AspNetCore.Http;

namespace Session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int number = HttpContext.Session.GetInt32("number") ?? 22;
        HttpContext.Session.SetInt32("number", number);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpPost("user/create")]
    public IActionResult CreateUser(string name)
    {
        if (name is not null)
        {
            HttpContext.Session.SetString("name", value: name);
            return RedirectToAction("Privacy");
        }
        return RedirectToAction("Index");
    }

    [HttpPost("AddOne")]
    public IActionResult AddOne()
    {
        int number = HttpContext.Session.GetInt32("number") ?? 22;
        number += 1;
        HttpContext.Session.SetInt32("number", number);
        return RedirectToAction("Privacy");
    }
    [HttpPost("timesTwo")]
    public IActionResult timesTwo()
    {
        int number = HttpContext.Session.GetInt32("number") ?? 22;
        number = number * 2;
        HttpContext.Session.SetInt32("number", number);
        return RedirectToAction("Privacy");
    }
    [HttpPost("moinUn")]
    public IActionResult moinUn()
    {
        int number = HttpContext.Session.GetInt32("number") ?? 22;
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!
        number -= 1;
        //!!!!!!!!!!!!!!!!!!!!!!!!!

        HttpContext.Session.SetInt32("number", number);
        return RedirectToAction("Privacy");
    }
    [HttpPost("Random")]
    public IActionResult Random()
    {
        int number = HttpContext.Session.GetInt32("number") ?? 22;
        Random random = new Random();
        int randomIncrement = random.Next(1, 100);
        number += randomIncrement;
        HttpContext.Session.SetInt32("number", number);
        return RedirectToAction("Privacy");
    }
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}