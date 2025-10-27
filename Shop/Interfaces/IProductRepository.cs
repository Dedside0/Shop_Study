using Shop.Models;

namespace Shop.Repositories;

public interface IProductRepository
{
    List<Product> GetAll();
    Product GetById(int id);
    void Add(string name, decimal cost,   string description);

}