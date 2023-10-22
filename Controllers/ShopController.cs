using Microsoft.AspNetCore.Mvc;
using AspNetMVC.Models;
using System.Collections.Generic;

public class ShopController : Controller
{
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registration(User user)
    {
        if (user.Age >= 16)
        {
            var products = new List<Product>
            {
                new Product { Name = "Pizza 1", Quantity = 0 },
                new Product { Name = "Pizza 2", Quantity = 0 },
                new Product { Name = "Pizza 3", Quantity = 0 }
            };
            user.Products = products;
            return View("OrderMenu", user);

        }
        else
        {
            return Content("You must be over 16 years old");
        }
    }

    [HttpPost]
    public IActionResult OrderMenu(User user)
    {
        return View("OrderList", user);
    }

    [HttpPost]
    public IActionResult OrderList(List<Product> products)
    {
        if (products.Any(product => product.Quantity < 0))
        {
            return Content("Amount of selected product must be >= 0");

        }
        else
        {
            return View(products);
        }
    }
}