using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int productId)
        {
            var product = ProductRepository.GetById(productId);
            return View(product);
        }

        public IActionResult Add(string name,decimal cost, string description)
        {
            ProductRepository.Add(name,cost,description);
            return RedirectToAction("Index", "Home");
            
        }
    }
}