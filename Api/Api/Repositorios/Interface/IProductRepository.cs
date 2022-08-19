using Api.Entidades;
using System.Collections.Generic;

namespace Api.Repositorios.Interface
{
    public interface IProductRepository
    {
        Product GetProduct(long id);
        List<Product> GetProducts();
        bool Save(Product product);
        bool Delete(long id);
    }
}
