using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Core.DataAcces;
using MultiShop.Core.DataAcces.MongoDB;
using MultiShop.DataAcces.Concrete.EntityFramework;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.DataAcces.Abstract
{
    public interface IProductDal  :IMongoRepository<Product>
    {
        List<ProductListDTO> GetProductByLanguage(string langcode);
        // Order by elemek ucun 
        List<RecentProductDTO> RecentProduct(string langcide);
        List<DiscountProductDTO> DiscountProduct(string langcide);
        ProductDetail GetProductDetail(string id , string lang);


        //

    }

}
