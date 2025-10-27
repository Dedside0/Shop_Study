using Shop.Models;

namespace Shop.Repositories;

public interface IFavoriteRepository
{
    void Add(Product product, string userId);
    void Remove(Product product, string userId);
    Favorite? TryGetById(string userId);
    void Clear(string userId);
}