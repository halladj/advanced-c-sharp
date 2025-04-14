using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Product
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController: Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Products[] productsList = new Products[]
            {
                new Products
                {
                    Id = 1,
                    Name = "Iphone",
                    Price = 100
                },
                new Products
                {
                    Id = 2,
                    Name = "Iphone",
                    Price = 100
                },
                new Products
                {
                    Id = 3,
                    Name = "Iphone",
                    Price = 100
                },
                new Products
                {
                    Id = 4,
                    Name = "Iphone",
                    Price = 100
                },
            };

            ViewData["products"] = productsList;
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult GetById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct()
        {
            return Ok();
        }

    }
}