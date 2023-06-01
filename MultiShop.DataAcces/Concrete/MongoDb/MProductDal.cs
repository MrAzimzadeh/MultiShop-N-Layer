using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Core.DataAcces.MongoDB.Concrete;
using MultiShop.Core.DataAcces.MongoDB.MongoSettings;
using MultiShop.DataAcces.Abstract;
using MultiShop.Entities.Concreate;

namespace MultiShop.DataAcces.Concrete.MongoDb
{
    public class MProductDal :  MongoRepository<Product> , IProductDal
    {
        public MProductDal(IDatabseSettings databseSettings) : base(databseSettings)
        {
        }
    }
}
