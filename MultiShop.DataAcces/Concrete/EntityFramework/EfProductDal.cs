using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Core.DataAcces.EntityFramework;
using MultiShop.DataAcces.Abstract;
using MultiShop.Entities.Concreate;

namespace MultiShop.DataAcces.Concrete.EntityFramework
{
    public class EfProductDal :EfRepositoryBase<Product , AppDbContext>  , IProductDal
    {

    }
}
