using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.Business.Abstract
{
    public interface IProductsServices
    {

        void AddProduct(ProductCreateDTO productCreateDto);
        List<Product> GetProducts();
        Product GetProductById(string id);

    }
}
