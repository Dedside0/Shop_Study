using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers;

public class FavoriteController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}