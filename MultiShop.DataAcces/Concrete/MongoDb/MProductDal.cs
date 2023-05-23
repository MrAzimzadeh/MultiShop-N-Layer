using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.DataAcces.Abstract;

namespace MultiShop.DataAcces.Concrete.MongoDb
{
    public class MProductDal : IProductDal
    {
        public void Add()
        {
            Console.WriteLine("M - product Add ");
        }
    }
}
