using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Business.Abstract;
using MultiShop.DataAcces.Abstract;
using MultiShop.Entities.Concreate;

namespace MultiShop.Business.Concreate
{
    public class ProducManager : IProductsServices
    {
        // Solid  - L Yer DAeyisme AL t kilas  lar ust kilaslari evez edir 
        private readonly IProductDal _productDal;

        public ProducManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        // bu method bize butun productlari getirir 
        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }

        public Product GetProductById(int id)
        {
            var product = _productDal.Get(x => x.Id == id);
            return product;
        }
    }
}
