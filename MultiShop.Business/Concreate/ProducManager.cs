using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Business.Abstract;
using MultiShop.DataAcces.Abstract;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs;

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

        public void AddProduct(ProductCreateDTO productCreateDto)
        {
            List<ProductLanguage> productLanguages = new();
            foreach (var pl in productCreateDto.ProductLanguages)
            {
                ProductLanguage productLanguage = new()
                {
                    Name = pl.Name,
                    Description = pl.Description,
                    LangCode = pl.LangCode,
                    SeoUrl = "",
                };
                productLanguages.Add(productLanguage);
            }

            Product product = new()
            {
                ProductLanguages = productLanguages,
                Price = productCreateDto.Price,
                Discount = productCreateDto.Discount,
                DiscountEndDate = productCreateDto.DiscountEndDate,
                CreatedDate = DateTime.Now,
                Categories = productCreateDto.Categories,
                UpdatedDate = DateTime.Now,
                IsActive = false,
                IsDeleted = false,
                PhotoUrl = productCreateDto.PhotoUrl
            };
            _productDal.Add(product);
        }

        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }

        public Product GetProductById(string id)
        {
            var product = _productDal.Get(id);
            return product;
        }
    }
}
