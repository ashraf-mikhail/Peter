using System.Collections.Generic;
using Domain;

namespace DataAccess.Interface
{
    public interface IProductDataAccess
    {
        List<Product> GetProducts();
    }
}
