using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crud.Models;

namespace Crud.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;

        _context = context;
    }

    public IActionResult Index()
    {

        List<Dish> AllDishes = _context.Dishes.ToList();
        return View(AllDishes);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Edit(int dishId)
    {
        Dish dish = _context.Dishes.FirstOrDefault(a => a.DishId == dishId);
        return View(dish);
    }

    public IActionResult ViewOne(int dishId)
    {
        Dish dish = _context.Dishes.FirstOrDefault(a => a.DishId == dishId);
        return View(dish);
    }

    [HttpPost]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            //  Insert new Dish into Database (2 Steps)
            // 1  Add
            _context.Add(newDish);
            // 2 Save
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // Display Error messages
        return View("Privacy");
    }

    [HttpPost]
    public IActionResult UpdateDish(Dish dishToUpdate)
    {
        if (ModelState.IsValid)
        {
            // 1- Update
            Dish dish = _context.Dishes.FirstOrDefault(x => x.DishId == dishToUpdate.DishId);
            // Mapping
            dish.ChefName = dishToUpdate.ChefName;
            dish.DishName = dishToUpdate.DishName;
            dish.Calories = dishToUpdate.Calories;
            dish.Tostiness = dishToUpdate.Tostiness;
            dish.Description = dishToUpdate.Description;
            dish.UpdatedAt = DateTime.Now;
            //  2 - Save
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Edit");

    }
     [HttpPost]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? DishToDelete = _context.Dishes.FirstOrDefault(a => a.DishId == dishId);
        //  1 Delete
        _context.Dishes.Remove(DishToDelete);
        //  2 Save
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
