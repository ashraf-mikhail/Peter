using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussiness;
using DataAccess;
using Domain;

namespace Service.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductManager _productManager;
        public ProductManager ProductManager => _productManager ?? (_productManager  = new ProductManager(new ProductDataAccess()));

        // GET api/values
        [HttpGet]
        public List<Product> Get()
        {
            //ProductManager.ProductDataAccess = new ProductDataAccess();
            List<Product> products =  ProductManager.GetProducts();
            return products;
        }
    }
}
