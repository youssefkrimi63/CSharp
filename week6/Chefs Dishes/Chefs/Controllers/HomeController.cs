using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Chefs.Models;
using Microsoft.EntityFrameworkCore;

namespace Chefs.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private AppDbContext _context;     

    public HomeController(ILogger<HomeController> logger ,  AppDbContext context)
    {
        _logger = logger;

        _context = context;    
    }

    public IActionResult Index()
    {
           // Now any time we want to access our database we use _context   
        List<Chef> AllChefs = _context.Chefs.Include(d => d.AllDishes).ToList();
        return View(AllChefs);
    }

    public IActionResult Privacy()
    {
        List<Dish> AllDishes = _context.Dishes.Include(c =>c.Creator).ToList() ; 
        return View(AllDishes);
    }

       public IActionResult AddChef()
    {
        return View();
    }

       public IActionResult AddDish()
    {   
        ViewBag.chefs=_context.Chefs.ToList();
        return View();
    }

[HttpPost]
public IActionResult CreateChef(Chef newChef)
{
    if (ModelState.IsValid)
    {
        // Find the next available ChefId
        int nextChefId = _context.Chefs.Max(c => c.ChefId) + 1;

        // Set the ChefId of the new chef
        newChef.ChefId = nextChefId;

        // Add the new chef to the context
        _context.Add(newChef);

        // Save changes to the database
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // If model state is not valid, return the AddChef view with validation errors
    return View("AddChef");
}



    [HttpPost]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            // 1  Add
            _context.Add(newDish);
            // 2 Save
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        // Display Error messages
        return View("AddDish");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
