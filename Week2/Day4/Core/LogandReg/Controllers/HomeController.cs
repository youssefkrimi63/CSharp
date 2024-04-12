using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LogandReg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace LogandReg.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }
    [SessionCheck] //- Session check better way (using filter) ⬇️ Go To the Bottom ⬇️
    public IActionResult Privacy()
    {
        //- Session check old way
        // int? userIdFromSession = HttpContext.Session.GetInt32("userId");
        // if (userIdFromSession is not null)
        // {
        // return View();
        // }
        // return RedirectToAction("Index");
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            // 1- Email already exist ?
            bool result = _db.Users.Any(u => u.Email == user.Email);
            if (result)
            {
                ModelState.AddModelError("Email", "Email already in use. Hope by you 🤡.");
                return View("Index");
            }
            else
            {
                // 2 - Hash Password
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                // 3 - Add
                _db.Add(user);
                // 4 - Save
                _db.SaveChanges();
                // 5 - Store UserId in Session 
                HttpContext.Session.SetInt32("userId", user.UserId);
                HttpContext.Session.SetString("username", user.Username);
                // 6 - Redirect
                return RedirectToAction("Privacy");

            }
        }
        return View("Index");

    }

    [HttpPost]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            // 1 - Email exist ?
            User? userFromDb = _db.Users.FirstOrDefault(x => x.Email == loginUser.LoginEmail);
            if (userFromDb is not null)
            {
                // 2 - Password match
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(loginUser, userFromDb.Password, loginUser.LoginPassword);
                if (result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Wrong Password.");
                    return View("Index");
                }
                // 3 - Store UserId & Username in Session 
                HttpContext.Session.SetInt32("userId", userFromDb.UserId);
                HttpContext.Session.SetString("username", userFromDb.Username);
                // 4 - Redirect
                return RedirectToAction("Privacy");
            }
            ModelState.AddModelError("LoginEmail", "Email doesn't exist. Try to register.");
            return View("Index");
        }
        return View("Index");
    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    // public async Task<IActionResult> GetUsers()
    // {
    //     List<User> allUsers = await _db.Users.ToListAsync();
    //     return NoContent();
    // }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    //  - Session check Filter class
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Find the session, but remember it may be null so we need int?
            int? userId = context.HttpContext.Session.GetInt32("userId");
            // Check to see if we got back null
            if (userId == null)
            {
                // Redirect to the Index page if there was nothing in session
                // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}