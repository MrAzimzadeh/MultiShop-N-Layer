using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Core.DataAcces;
using MultiShop.DataAcces.Concrete.EntityFramework;
using MultiShop.Entities.Concreate;

namespace MultiShop.DataAcces.Abstract
{
    public interface IProductDal  :IRepositoryBase<Product>
    {

    }
}
