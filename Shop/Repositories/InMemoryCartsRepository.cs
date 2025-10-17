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
public class InMemoryCartsRepository:ICartRepository
{
    static List<Cart> _carts = [];

    public Cart? TryGetById(string userId)
    {
        return _carts.FirstOrDefault(x => x.UserId == userId);
    }

    public void Add(Product? product, string userId)
    {
        var existingCart = TryGetById(userId);

        if (existingCart == null)
        {
            existingCart = new Cart()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Items =
                [
                    new CartItem()
                    {
                        Product = product,
                        Id = Guid.NewGuid(),
                        Count = 1, 

                    }
                ]

            };
            _carts.Add(existingCart);
        }
        else
        {
            var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (existingCartItem == null)
            {
                var newCartItem = new CartItem()
                {
                    Product = product,
                    Id = Guid.NewGuid(),
                    Count = 1,
                };
                existingCart.Items.Add(newCartItem);
            }
            else
            {
                existingCartItem.Count++;
            }
        }
    }

    public void Remove(Product? product, string userId)
    {
        var existingCart = TryGetById(userId);

        if (existingCart != null)
        {
            var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (existingCartItem.Count == 1)
            {
                DeleteCartItem(existingCart,existingCartItem);
            }
            else
            {
                existingCartItem.Count--;
            }
        }
    }

    public void DeleteCartItem(Cart cart,CartItem cartItem)
    {
        cart.Items.Remove(cartItem);
    }

    public void Clear(string id)
    {
        var existingCart = TryGetById(id);
        if(existingCart != null) 
            _carts.Remove(existingCart);
    }
}