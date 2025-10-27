using Microsoft.AspNetCore.Mvc;
using Shop.Repositories;

namespace Shop.Controllers;

public class FavoriteController : Controller
{
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly IProductRepository _productRepository;

    public FavoriteController(IFavoriteRepository favoriteRepository, IProductRepository productRepository)
    {
        _favoriteRepository = favoriteRepository;
        _productRepository = productRepository;
    }

    // GET
    public IActionResult Index()
    {
        var favorite = _favoriteRepository.TryGetById(Constants.UserId);
        return View(favorite);
    }

    public IActionResult Add(int productId)
    {
        var product = _productRepository.GetById(productId);
        _favoriteRepository.Add(product, Constants.UserId);
        
        return RedirectToAction("Index");
    }

    public IActionResult Remove(int productId, string userId)
    {
        
        var product = _productRepository.GetById(productId);
        _favoriteRepository.Remove(product, Constants.UserId);
        
        return RedirectToAction("Index");
    }

    public IActionResult Clear(string userId)
    {
        _favoriteRepository.Clear(userId);
        return RedirectToAction("Index");
    }
}