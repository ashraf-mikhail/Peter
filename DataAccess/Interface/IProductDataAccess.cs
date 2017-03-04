using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess.Interface
{
    public interface IProductDataAccess
    {
        List<Product> GetProducts();
    }
}
