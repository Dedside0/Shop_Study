using Shop.Models;

namespace Shop.Repositories
{

    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(string name, decimal cost,   string description);
        static List<Product> Products;

    }
    public class ProductRepository: IProductRepository
    {
        private static int _instanceCounter = 0;
        private static readonly List<Product> _products =
        [
            new Product(++_instanceCounter, "Товар 1", 1000.0M, "Описание товара 1"),
            new Product(++_instanceCounter, "Товар 2", 2000.0M, "Описание товара 2"),
            new Product(++_instanceCounter, "Товар 3", 3000.0M, "Описание товара 3"),
            new Product(++_instanceCounter, "Товар 4", 4000.0M, "Описание товара 4"),
            new Product(++_instanceCounter, "Товар 5", 5000.0M, "Описание товара 5")
        ];
        public List<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(x => x.Id == id);

        public void Add(string name, decimal cost,   string description)
        {
            _products.Add(new Product(++_instanceCounter, name, cost, description));
        }
    }
}
