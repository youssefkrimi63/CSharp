using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LogReg.Models;
using Microsoft.AspNetCore.Identity;

namespace LogReg.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            // We passed the validation
            // we need to check if the email is unique
            if (_context.Users.Any(a => a.Email == newUser.Email))
            {
                // we have a problem. this user already has this email in DB
                ModelState.AddModelError("Email", "Email is already in use!");
                return View("Index");

            }
            // import Identity
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }
    [HttpPost("user/login")]
    public IActionResult Login(LoginUser LogUser)
    {
        if (ModelState.IsValid)
        {
            // step 1 : find their email and if we can't find it throw an error
            User userInDb = _context.Users.FirstOrDefault(a => a.Email == LogUser.LoginEmail);
            if (userInDb == null)
            {
                // there was no Email in the database
                ModelState.AddModelError("LoginEmail", "Invalid Login Attempt");
                return View("Index");
            }
            PasswordHasher<LoginUser> PasswordHasher = new PasswordHasher<LoginUser>();

            var result = PasswordHasher.VerifyHashedPassword(LogUser, userInDb.Password, LogUser.LoginPassword);
            if (result == 0)
            {
                // this is a problem, we did not have any match of your password 
                ModelState.AddModelError("LoginEmail", "Invalid Login Attempt");
                return View("Index");
            }

            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");

        }
    }
    [HttpGet("Success")]
    public IActionResult Success()
    {
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
