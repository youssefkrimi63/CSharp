using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class CategoryController : Controller
{
    private ProductsAndCategoriesContext _context;
    
    public CategoryController(ProductsAndCategoriesContext context)
    {
        _context = context;
    }

    [HttpGet("category")]
    public IActionResult Categories()
    {
        List<Category> AllCategories = _context.Categories.ToList();

        return View("CategoriesMain", AllCategories);
    }


    // Create Category
    [HttpPost("category")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid == false)
        {
            return Categories();
        }

        _context.Categories.Add(newCategory);
        _context.SaveChanges();

        return RedirectToAction("Categories");
    }


    // Show One Category
    [HttpGet("category/{categoryId}")]
    public IActionResult ViewCategory(int categoryId)
    {
        ViewBag.oneCategory = _context.Categories
        .Include(categoryId => categoryId.CategoryProducts)
            .ThenInclude(catProd => catProd.Product)
        .FirstOrDefault(cat => cat.CategoryId == categoryId);

        ViewBag.products = _context.Products
        .Include(prod => prod.ProductCategories)
            .ThenInclude(prodCat => prodCat.Category)
                .Where(z => !z.ProductCategories.Any(z => z.CategoryId == categoryId))
        .ToList();

        if (ViewBag.oneCategory == null)
        {
            return RedirectToAction("Index", "Product");
        }

        return View("ViewCategory");
    }

    [HttpPost("category/{categoryId}/edit")]
    public IActionResult AddProduct(int categoryId, Association newAss)
    {
        newAss.CategoryId = categoryId;

        _context.Associations.Add(newAss);
        _context.SaveChanges();

        return RedirectToAction("ViewCategory", new { categoryId = newAss.CategoryId});
    }
}