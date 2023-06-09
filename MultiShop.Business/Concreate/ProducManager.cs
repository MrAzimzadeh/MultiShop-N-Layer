﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Business.Abstract;
using MultiShop.DataAcces.Abstract;
using MultiShop.DataAcces.Concrete.MongoDb;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.CartDTO;
using MultiShop.Entities.DTOs.Category;
using MultiShop.Entities.DTOs.ProductDTOs;

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

        #region CRUD
        public void AddProduct(ProductCreateDTO productCreateDto)
        {
            List<ProductLanguage> productLanguages = new();
            int count = 0;
            foreach (var pl in productCreateDto.ProductLanguages)
            {
                ProductLanguage productLanguage = new()
                {
                    Name = pl.Name,
                    Description = pl.Description,
                    LangCode = count == 0 ? "Az" : count == 1 ? "Ru" : "En",
                    SeoUrl = "",
                };
                count++;
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
        public void UpdateProduct(string id, ProductUpdateDTO productUpdateDto)
        {
            List<ProductLanguage> productLanguages = new();
            foreach (var productLang in productUpdateDto.ProductLanguages)
            {
                ProductLanguage productLanguage = new()
                {
                    LangCode = productLang.LangCode,
                    Name = productLang.Name,
                    Description = productLang.Description,
                    SeoUrl = "lggjk"
                };
                productLanguages.Add(productLanguage);
            }
            Product product = new()
            {
                Id = id,
                PhotoUrl = productUpdateDto.PhotoUrl,
                Categories = productUpdateDto.Categories,
                CreatedDate = productUpdateDto.CreatedDate,
                Discount = productUpdateDto.Discount,
                Price = productUpdateDto.Price,
                DiscountEndDate = productUpdateDto.DiscountEndDate,
                IsActive = productUpdateDto.IsActive,
                IsDeleted = productUpdateDto.IsDeleted,
                ProductLanguages = productLanguages,
                UpdatedDate = DateTime.Now
            };
            _productDal.Update(id, product);
        }
        public void ProductRemoveById(string id)
        {
            var result = _productDal.Get(id);
            _productDal.Remove(result.Id);
        }


        #endregion

        #region  Get
        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }

        public Product GetProductById(string id)
        {
            var product = _productDal.Get(id);
            return product;
        }
        public List<ProductListDTO> GetProductList(string lang)
        {
            var products = _productDal.GetAll();

            var result = products.Select(x => new ProductListDTO()
            {
                Id = x.Id,
                PhotoUrl = x.PhotoUrl,
                Name = x.ProductLanguages.FirstOrDefault(x => x.LangCode == lang).Name,
                SeoUrl = x.ProductLanguages.FirstOrDefault(x => x.LangCode == lang).SeoUrl,
                LangCode = x.ProductLanguages.FirstOrDefault(x => x.LangCode == lang).LangCode,
                Discount = x.Discount,
                Price = x.Price,
                Categories = x.Categories,
                CreatedDate = x.CreatedDate,
                Description = x.ProductLanguages.FirstOrDefault(x => x.Description == lang).Description,
                DiscountEndDate = x.DiscountEndDate,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                UpdatedDate = x.UpdatedDate

            }).ToList();

            return result;
        }

        public List<ProductListDTO> GetDashboardProducts(string langcode)
        {

            return _productDal.GetProductByLanguage(langcode);

        }

        public ProductUpdateDTO GetProductUpdateById(string id)
        {
            var result = _productDal.Get(id);
            ProductUpdateDTO productUpdate = new()
            {
                Id = result.Id,
                Categories = result.Categories,
                CreatedDate = result.CreatedDate,
                Discount = result.Discount,
                Price = result.Price,
                DiscountEndDate = result.DiscountEndDate,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDate = result.UpdatedDate,
                PhotoUrl = result.PhotoUrl,
                ProductLanguages = result.ProductLanguages

            };
            return productUpdate;
        }

        public ProductRemove GetProductRemoveById(string id)
        {
            var product = _productDal.Get(id);
            ProductRemove productRemove = new()
            {
                Id = id,
                PhotoUrl = product.PhotoUrl,
                ProductLanguage = product.ProductLanguages,
            };
            return productRemove;
        }

        public List<RecentProductDTO> RecentProductList(string langcide)
        {
            return _productDal.RecentProduct(langcide);
        }

        public List<DiscountProductDTO> discountProduct(string langcide)
        {
            return _productDal.DiscountProduct(langcide);
        }

        public List<CartProductDTO> GetProductsById(string langcode, List<string> id, List<int> quantity)
        {
            var products = _productDal.GetProductByLanguage(langcode);

            List<CartProductDTO> result = new();


            for (int i = 0; i < id.Count; i++)
            {
                var findProduct = products.FirstOrDefault(x => x.Id == id[i]);
                CartProductDTO cartProductDTO = new()
                {
                    Id = findProduct.Id,
                    Name = findProduct.Name,
                    Price = findProduct.Price,
                    Quantity = quantity[i],
                    PhotoUrl = findProduct.PhotoUrl[0]
                };

                result.Add(cartProductDTO);
            }
            return result;
        }

        public List<RecentProductDTO> GetAllFilteredProductList(string langcode, decimal? minPrice, decimal? maxPrice, string? categoryId, bool IsDiscounted, int page = 0)
        {
            return _productDal.FilterProducts(langcode, minPrice, maxPrice, categoryId, IsDiscounted,page);
        }

        public List<DiscountProductDTO> DiscountProductList(string langcode)
        {
            throw new NotImplementedException();
        }

        public ProductDetail GetDetailByIdLangCode(string id, string langcide)
        {
            return _productDal.GetProductDetail(id, langcide);
        }


        #endregion


    }
}
