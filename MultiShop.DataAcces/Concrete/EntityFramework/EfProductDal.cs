using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.DataAcces.Abstract;

namespace MultiShop.DataAcces.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add()
        {
            Console.WriteLine("Ef  - product Add ");
        }
    }
}
