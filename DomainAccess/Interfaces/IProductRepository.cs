using Domain.Entities;
using System.Collections.Generic;

namespace DomainAccess.Interfaces
{
    public interface IProductRepository
    {
        Result<IEnumerable<Product>> GetAllProduct();
        Result<Product> GetProductById(int id);
        Result<IEnumerable<Product>> AddProduct(Product product);
        Result<IEnumerable<Product>> DeleteProduct(int id);
    }
}
