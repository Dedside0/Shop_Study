using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = CartRepository.TryGetById(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = ProductRepository.GetById(productId);
            CartRepository.Add(product,Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {
            var product = ProductRepository.GetById(productId);
            CartRepository.Remove(product,Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Clear(string userId)
        {
            CartRepository.Clear(userId);

            return RedirectToAction("Index");
        }
    }
}
