using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussiness;
using DataAccess;
using Domain;
using log4net;

namespace Service.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductManager _productManager;
        public ProductManager ProductManager => _productManager ?? (_productManager  = new ProductManager(new ProductDataAccess()));

        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/values
        [HttpGet]
        public List<Product> Get()
        {
            //Log.Debug("GET Request traced");
            //ProductManager.ProductDataAccess = new ProductDataAccess();
            List<Product> products =  ProductManager.GetProducts();
            return products;
        }
    }
}
