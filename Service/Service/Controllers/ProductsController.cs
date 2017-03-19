using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using Autofac;
using Bussiness;
using DataAccess;
using DataAccess.Interface;
using Domain;

namespace Service.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductManager _productManager;
        //public ProductManager ProductManager => _productManager ?? (_productManager  = new ProductManager(new ProductDataAccess()));

        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        // GET api/values
        [HttpGet]
        public List<Product> Get()
        {
            //var builder = new ContainerBuilder();
            //builder.Register(c => new ProductManager(c.Resolve<IProductDataAccess>()));
            //builder.RegisterType<ProductManager>().As<IProductManager>();
            //builder.RegisterType<ProductDataAccess>().As<IProductDataAccess>();

            //using (var container = builder.Build())
            //{
            //    List<Product> products = container.Resolve<ProductManager>().GetProducts();
            //    return products;
            //}

            List<Product> products = _productManager.GetProducts();
            return products;

            //List<Product> products =  ProductManager.GetProducts();

        }
    }
}
