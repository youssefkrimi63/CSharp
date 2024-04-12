using Microsoft.AspNetCore.Mvc;

namespace Practice.Controllers;  
public class HomeController : Controller   
{      
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

        [HttpGet("projects")]    
    public ViewResult Projects()        
    {            
        return View("Projects");        
    }    

    [HttpGet("contact")] 
    public ViewResult Contact()        
    {            
        return View();        
    }   
}