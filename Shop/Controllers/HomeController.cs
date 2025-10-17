using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;
using System.Diagnostics;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }
    }
    
}
