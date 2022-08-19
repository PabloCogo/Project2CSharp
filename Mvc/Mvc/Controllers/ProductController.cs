using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    public class ProductController:Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        public bool InsertProduct(ProductModel product)
        {
            var Client = new RestClient("https://localhost:44382/");
            var Request = new RestRequest("Product/insertProduct", Method.Post);
            Request.AddBody(product);
            return Client.Execute<bool>(Request).Data;
        }
        public IEnumerable<ProductModel> GetProducts()
        {
            var Client = new RestClient("https://localhost:44382/");
            var Request = new RestRequest("Product/getProducts",Method.Get);
            return Client.Execute<List<ProductModel>>(Request).Data;
        }
        public ProductModel GetProduct(long id)
        {
            var Client = new RestClient("https://localhost:44382/");
            var Request = new RestRequest("Product/getProduct",Method.Get);
            Request.AddParameter("id", id);
            return Client.Execute<ProductModel>(Request).Data;
        }
        public bool DeleteProduct(long id)
        {
            var Client = new RestClient("https://localhost:44382/");
            var Request = new RestRequest("Product/deleteProduct",Method.Delete);
            Request.AddParameter("id", id);
            return Client.Execute<bool>(Request).Data;
        }
        public IActionResult Index()
        {
            ViewBag.products = GetProducts();
            return View();
        }
        public IActionResult NewProduct()
        {
            return View();
        }
        public IActionResult Excluir(long id)
        {
            DeleteProduct(id);
            return RedirectToAction("Index", "Product");
        }
        public IActionResult Editar(long id)
        {
            var product = GetProduct(id);
            var model = new ProductModel()
            {
                Id = product.Id,
                Product_title = product.Product_title,
                Barcode = product.Barcode
            };
            return View("NewProduct", model);
        }
        [HttpPost]
        public IActionResult NewProduct(ProductModel Product)
        {
            if (InsertProduct(Product))
            {
                return RedirectToAction("NewProduct", "Product");
            }
            return View();
        }
    }
}
