using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class ProductController : Controller
{
    private ProductsAndCategoriesContext _context;
    
    public ProductController(ProductsAndCategoriesContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Product> AllProducts = _context.Products.ToList();

        return View("Index", AllProducts);
    }


    // Create Product
    [HttpPost("product")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid == false)
        {
            return Index();
        }

        _context.Products.Add(newProduct);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }


    // Show One Product
    [HttpGet("product/{productId}")]
    public IActionResult ViewProduct(int productId)
    {
        ViewBag.oneProduct = _context.Products
            .Include(product => product.ProductCategories)
                .ThenInclude(prodCat => prodCat.Category)
            .FirstOrDefault(product => product.ProductId == productId);

        ViewBag.categories = _context.Categories
            .Include(cat => cat.CategoryProducts)
                .ThenInclude(catProd => catProd.Product)
                    .Where(z => !z.CategoryProducts.Any(z => z.ProductId == productId))
            .ToList();

        if (ViewBag.oneProduct == null)
        {
            return RedirectToAction("Index");
        }

        return View("ViewProduct");
    }


    // Add Category to Product
    [HttpPost("product/{productId}/edit")]
    public IActionResult AddCategory(int productId, Association newAss)
    {
        newAss.ProductId = productId;

        _context.Associations.Add(newAss);
        _context.SaveChanges();

        return RedirectToAction("ViewProduct", new { productId = newAss.ProductId });
    }
}