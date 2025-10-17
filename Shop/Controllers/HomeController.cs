using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;
using System.Diagnostics;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductRepository.GetAll();
            return View(products);
        }
    }
}
