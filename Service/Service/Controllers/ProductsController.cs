using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussiness;
using Domain;

namespace Service.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductManager _productManager;
        public ProductManager ProductManager => _productManager ?? (_productManager  = new ProductManager());

        // GET api/values
        [HttpGet]
        public List<Product> Get()
        {
            List<Product> products =  ProductManager.GetProducts();
            return products;
        }
    }
}
