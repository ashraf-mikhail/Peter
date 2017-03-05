using System.Collections.Generic;
using DataAccess.Interface;
using Domain;

namespace Bussiness
{
    public class ProductManager
    {
        private IProductDataAccess _productDataAccess;

        //public IProductDataAccess ProductDataAccess
        //{
        //    set
        //    {
        //        this._productDataAccess = value;
        //    }
        //}

        public ProductManager(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }


        public List<Product> GetProducts()
        {
           return _productDataAccess.GetProducts();
        }
    }
}
