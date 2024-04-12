using Microsoft.AspNetCore.Mvc;
namespace RazorFun.Controllers;   
public class HelloController : Controller 
{      
    [HttpGet("")]
    public ViewResult Index()        
    {            
    	return View("Index");        
    }    
}