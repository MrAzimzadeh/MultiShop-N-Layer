using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MultiShop.DataAcces.Abstract;
using MultiShop.Entities.Concreate;

namespace MultiShop.DataAcces.Concrete.MongoDb
{
    public class MProductDal : IProductDal
    {
        public void Add(Product model)
        {
            throw new NotImplementedException();
        }

        public void Update(Product model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product model)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
