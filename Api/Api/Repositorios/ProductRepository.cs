using Api.Context;
using Api.Entidades;
using Api.Repositorios.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Api.Repositorios
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiContext _context;

        public ProductRepository(ApiContext context)
        {
            _context = context;
        }
        public Product GetProduct(long id)
        {
            return _context.Products.Where(c => c.Id == id).FirstOrDefault();
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public bool Save(Product product)
        {
            try
            {
                if(product.Id == 0)
                    _context.Products.Add(product);
                else
                    _context.Products.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                _context.Products.Remove(GetProduct(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
