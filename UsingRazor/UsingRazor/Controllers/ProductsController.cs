using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingRazor.Models;

namespace UsingRazor.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = new Product();

            products.ProductList = new List<Product> {
                new Product { Id = 1,
                    Name = "Kayak",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 275M },

                new Product { Id = 2,
                    Name = "Canoe",
                    Description = "A boat for two people",
                    Category = "Watersports",
                    Price = 275M },
                new Product { Id = 3,
                    Name = "Inflatable",
                    Description = "A boat for four people",
                    Category = "Watersports",
                    Price = 375M },
                new Product { Id = 4,
                    Name = "ATV",
                    Description = "more fun than boats",
                    Category = "Offroad",
                    Price = 375M }
                };

            var pList = products.ProductList.Where(p => p.Category == "Watersports");

            return View(pList);
        }
    }
}