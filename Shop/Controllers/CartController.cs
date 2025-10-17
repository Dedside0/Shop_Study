using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartController(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var cart = _cartRepository.TryGetById(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = _productRepository.GetById(productId);
            _cartRepository.Add(product,Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {
            var product = _productRepository.GetById(productId);
            _cartRepository.Remove(product,Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Clear(string userId)
        {
            _cartRepository.Clear(userId);

            return RedirectToAction("Index");
        }
    }
}
