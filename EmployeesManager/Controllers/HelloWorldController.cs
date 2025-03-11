using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.HelloWorld
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
