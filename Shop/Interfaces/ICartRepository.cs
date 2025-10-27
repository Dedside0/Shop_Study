using Shop.Models;

namespace Shop.Repositories;

public interface ICartRepository
{
    Cart? TryGetById(string userId);
    public void Add(Product? product, string userId);
    static List<Cart> Carts;
    void Clear(string id);
    void DeleteCartItem(Cart cart, CartItem cartItem);
    void Remove(Product? product, string userId);
}