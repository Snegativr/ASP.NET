using AspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var product = new List<Product>
            {
                new Product { ID = 1, Name = "Product 1", Price = 111, CreatedDate = DateTime.Now },
                new Product { ID = 2, Name = "Product 2", Price = 222, CreatedDate = DateTime.Now.AddMinutes(-500) },
                new Product { ID = 3, Name = "Product 3", Price = 333, CreatedDate = DateTime.Now.AddDays(-900) }
            };
            return View(product);
        }
    }
}