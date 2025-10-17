using Shop.Models;

namespace Shop.Repositories;

public static class CartRepository
{
    static List<Cart> _carts = [];

    public static Cart? TryGetById(string userId)
    {
        return _carts.FirstOrDefault(x => x.UserId == userId);
    }

    public static void Add(Product? product, string userId)
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

    public static void Remove(Product? product, string userId)
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

    public static void DeleteCartItem(Cart cart,CartItem cartItem)
    {
        cart.Items.Remove(cartItem);
    }

    public static void Clear(string id)
    {
        var existingCart = TryGetById(id);
        if(existingCart != null) 
            _carts.Remove(existingCart);
    }
}