using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Bussiness
{
    interface IProductManager
    {
        List<Product> GetProducts();
    }
}
