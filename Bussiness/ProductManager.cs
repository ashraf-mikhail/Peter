using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Domain;

namespace Bussiness
{
    public class ProductManager
    {
        public ProductDataAccess _productDataAccess;

        public ProductDataAccess ProductDataAccess
            => _productDataAccess ?? (_productDataAccess = new ProductDataAccess());

        public ProductManager()
        {
            ProductDataAccess Aa = new ProductDataAccess();
        }


        public List<Product> GetProducts()
        {
           return  ProductDataAccess.GetProducts();
        }
    }
}
