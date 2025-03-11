
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]

public class HelloWorldController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        // return "This is my default action...";
        ViewData["Message"] = "Hello " + "nooo";
        ViewData["NumTimes"] = 4;
        return View();
    }
    
    
}
