using Microsoft.AspNetCore.Mvc;
namespace Portfolio1;
public class HomeController : Controller
{
    //[HttpGet("")]
    public string Project()
    {
        return("This is my Index!");
    }
   // [HttpGet("projects")]
    public string Projects()
    {
        return("these are my projects");
    }
    [HttpGet("Contact")]
    public string Contact()
    {
        return("This is my contact!");
    }
}