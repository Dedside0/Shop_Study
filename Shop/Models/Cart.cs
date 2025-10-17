using Shop.Repositories;

namespace Shop.Models
{
    public class Cart
    {
        public List<CartItem> Items = new List<CartItem>();
        public string? UserId { get; set; }
        public Guid Id { get; set; } 
        public decimal Total => Items.Sum(x => x.Total);


    }
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal Total { get => Count * Product.Cost; }

    }
}
