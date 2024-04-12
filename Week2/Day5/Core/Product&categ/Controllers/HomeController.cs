using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.Controllers;

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
        ViewBag.AllProducts = _context.Products.ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult CreateCategorie(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            // 1  Add
            _context.Add(newCategory);
            // 2 Save
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }

        return View("Privacy", newCategory);
    }

    [HttpPost]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            // 1  Add
            _context.Add(newProduct);
            // 2 Save
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.AllProducts = _context.Products.ToList();
        return View("Index");
    }

    public IActionResult OneProduct(int productId)
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        Product oneProduct = _context.Products.Include(p=> p.ProductCategoies).FirstOrDefault(w => w.ProductId == productId);
        return View(oneProduct);
    }

     [HttpPost]
    public IActionResult AddAssociation(Association association)
    {

            //Get
        Product product = _context.Products.FirstOrDefault(p => p.ProductId ==association.ProductId);

                //Add
                _context.Add(association);
                //Save
                _context.SaveChanges();
                ViewBag.AllCategories = _context.Categories.ToList();
        Product oneProduct = _context.Products.Include(p=> p.ProductCategoies).FirstOrDefault(w => w.ProductId == association.ProductId);
        //Redirect
        return View("OneProduct" , oneProduct);
    }

    public IActionResult OneCategorie(int categoryId)
    {
        ViewBag.AllProducts = _context.Products.ToList();
        Category oneCategory = _context.Categories.Include(p=> p.Associations).FirstOrDefault(w => w.CategoryId == categoryId);
        return View(oneCategory);
    }

      [HttpPost]
    public IActionResult create(Association association)
    {

            //Get
        Category category = _context.Categories.FirstOrDefault(p => p.CategoryId ==association.CategoryId);

                //Add
                _context.Add(association);
                //Save
                _context.SaveChanges();
               ViewBag.AllProducts = _context.Products.ToList();
        Category oneCategory = _context.Categories.Include(p=> p.Associations).FirstOrDefault(w => w.CategoryId == association.CategoryId);
        return View("OneCategorie" , oneCategory);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

