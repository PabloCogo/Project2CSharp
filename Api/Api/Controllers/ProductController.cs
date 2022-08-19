using Api.Entidades;
using Api.Repositorios.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost]
        [Route("insertProduct")]
        public bool InsertProduct([FromBody]Product product)
        {
            try
            {
                return _productRepository.Save(product);
            }
            catch
            {
                return false;
            }
        }
        [HttpGet]
        [Route("getProduct")]
        public Product GetProduct(long id)
        {
            return _productRepository.GetProduct(id);
        }
        [HttpGet]
        [Route("getProducts")]
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        [HttpDelete]
        [Route("deleteProduct")]
        public bool DeleteProduct(long id)
        {
            try
            {
                return _productRepository.Delete(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
