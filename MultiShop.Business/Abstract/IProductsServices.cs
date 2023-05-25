using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Entities.Concreate;

namespace MultiShop.Business.Abstract
{
    public interface IProductsServices
    {

        List<Product> GetProducts();

    }
}
