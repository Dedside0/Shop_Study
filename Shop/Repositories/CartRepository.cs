using Shop.Models;

namespace Shop.Repositories;

public interface ICartRepository
{
    Cart? TryGetById(string userId);
    public void Add(Product? product, string userId);
    static List<Cart> Carts;
}
public class CartRepository:ICartRepository
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
}