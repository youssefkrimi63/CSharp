using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
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
    
    public WeddingController(WeddingPlannerContext context)
    {
        _context = context;
    }

    // Dashboard Page
    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        if (loggedIn)
        {
            ViewBag.weddings = _context.Weddings
                .Include(w => w.Guests)
                    .ThenInclude(g => g.User)
                .Include(w => w.Creator)
                .ToList();

            return View("Dashboard");
        }


        return RedirectToAction("Index", "User");
    }

    // New Wedding Page
    [HttpGet("wedding/new")]
    public IActionResult NewWedding()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        return View("NewWedding");
    }

    // Create Wedding
    [HttpPost("wedding")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (ModelState.IsValid == false)
        {
            return NewWedding();
        }

        if (uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        newWedding.UserId = (int)uid;

        _context.Weddings.Add(newWedding);
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    // View One Wedding
    [HttpGet("wedding/{weddingId}")]
    public IActionResult ViewWedding(int weddingId)
    {
        ViewBag.oneWedding = _context.Weddings
            .Include(w => w.Guests)
                .ThenInclude(g => g.User)
        .FirstOrDefault(w => w.WeddingId == weddingId);

        if (ViewBag.oneWedding == null)
        {
            return RedirectToAction("Dashboard");
        }

        return View("ViewWedding");
    }

    // RSVP for Wedding
    [HttpPost("wedding/{weddingId}/rsvp")]
    public IActionResult RSVP(int weddingId, RSVP newRSVP)
    {
        if (uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        RSVP? existingRSVP = _context.RSVPs.FirstOrDefault(r => r.UserId == uid && r.WeddingId == weddingId);

        if (existingRSVP == null)
        {
            newRSVP.WeddingId = weddingId;
            newRSVP.UserId = (int)uid;

            _context.RSVPs.Add(newRSVP);
            
        }
        else
        {
            _context.Remove(existingRSVP);
        }

        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    // Delete Wedding
    [HttpPost("wedding/{weddingId}/delete")]
    public IActionResult DeleteWedding(int weddingId)
    {
        Wedding? delWed = _context.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);

        if (delWed != null)
        {
            if (delWed.UserId == uid)
            {
                _context.Weddings.Remove(delWed);
                _context.SaveChanges();
            }
        }

        return RedirectToAction("Dashboard");
    }
}