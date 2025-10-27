using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;

namespace Shop.Controllers;

public class OrderController : Controller
{
    private readonly ICartRepository _cartRepository;

    public OrderController(ICartRepository cart)
    {
        _cartRepository = cart;
    }
    
    public IActionResult Index()
    {
        var cart = _cartRepository.TryGetById(Constants.UserId);
        return View(cart);
    }

    public string Succes()
    {
        _cartRepository.Clear(Constants.UserId);
        return "Оплата прошла";
    }
}