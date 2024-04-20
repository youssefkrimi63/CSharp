using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers;

public class UserController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }
    
    private WeddingPlannerContext _context;
    
    public UserController(WeddingPlannerContext context)
    {
        _context = context;
    }

    // Login/Register Page
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    // Register New User
    [HttpPost("user/register")]
    public IActionResult RegisterUser(User newUser)
    {
        if (_context.Users.Any(user => user.Email == newUser.Email))
        {
            ModelState.AddModelError("Email", "is already registered");
        }

        if (ModelState.IsValid == false)
        {
            return Index();
        }

        PasswordHasher<User> hashPoint = new PasswordHasher<User>();
        newUser.Password = hashPoint.HashPassword(newUser, newUser.Password);

        _context.Users.Add(newUser);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        HttpContext.Session.SetString("UserFirstName", newUser.FirstName);
        
        return RedirectToAction("Dashboard", "Wedding");
    }

    // Login User
    [HttpPost("user/login")]
    public IActionResult LoginUser(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            return Index();
        }

        User? dbUser = _context.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

        if (dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "Invalid Email or Password");
            return Index();
        }

        PasswordHasher<LoginUser> hashPoint = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwResult = hashPoint.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if (pwResult == 0)
        {
            ModelState.AddModelError("LoginEmail", "Invalid Email or Password");
            return Index();
        }

        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        HttpContext.Session.SetString("UserFirstName", dbUser.FirstName);

        return RedirectToAction("Dashboard", "Wedding");
    }

    // Logout User
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Dashboard", "Wedding");
    }
}