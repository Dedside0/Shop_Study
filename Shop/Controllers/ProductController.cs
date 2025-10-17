using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index(int productId)
        {
            Console.WriteLine(productId);
            var product = _productRepository.GetById(productId);
            return View(product);
        }

        public IActionResult Add(string name,decimal cost, string description)
        {
            _productRepository.Add(name,cost,description);
            return RedirectToAction("Index", "Home");
            
        }
    }
}