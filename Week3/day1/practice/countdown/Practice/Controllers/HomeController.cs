using Microsoft.AspNetCore.Mvc;
namespace Practice.Controllers;   
public class HomeController : Controller
{      
    [HttpGet("")]
    public ViewResult Index()        
    {            
    	return View("Index");        
    }
}