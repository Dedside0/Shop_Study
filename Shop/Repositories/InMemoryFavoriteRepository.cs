using Shop.Models;

namespace Shop.Repositories;

public class InMemoryFavoriteRepository : IFavoriteRepository
{
    static List<Favorite> _favorites = [];

    public Favorite? TryGetById(string userId)
    {
        return _favorites.FirstOrDefault(x => x.UserId == userId);
    }

    public void Add(Product product, string userId)
    {
        var existingFavorite = TryGetById(userId);
        if (existingFavorite == null)
        {
            existingFavorite = new Favorite()
            {
                UserId = userId,
                Id = Guid.NewGuid(),
                Items =
                [
                    new FavoriteItem()
                    {
                        Product = product,
                        Id = Guid.NewGuid()
                    }
                ]
            };
            _favorites.Add(existingFavorite);
        }
        else
        {
            if (existingFavorite.Items.FirstOrDefault(x => x.Product.Id == product.Id) == null)
            {
                existingFavorite.Items.Add(new FavoriteItem()
                {
                    Product = product,
                    Id = Guid.NewGuid(),
                });
            }
        }
    }

    public void Remove(Product product, string userId)
    {
        var existingFavorite = TryGetById(userId);
        if (existingFavorite != null)
        {
            existingFavorite.Items.Remove(existingFavorite.Items.First(x => x.Product.Id == product.Id));
        }
    }

    public void Clear(string userId)
    {
        var existingFavorite = TryGetById(userId);
        if (existingFavorite != null)
            _favorites.Remove(existingFavorite);
    }
}