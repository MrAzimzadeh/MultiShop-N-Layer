﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Misc;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.Category;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.Business.Abstract
{
    public interface IProductsServices
    {

        // Add 
        void AddProduct(ProductCreateDTO productCreateDto);
        // All Product 
        List<Product> GetProducts();

        //getBy Id
        Product GetProductById(string id);
        //Detail ID
        ProductDetail GetDetailByIdLangCode(string id , string langcide);


        // Get Language 
        List<ProductListDTO> GetProductList(string lang);

        List<ProductListDTO> GetDashboardProducts(string langcode);

        // Update
        ProductUpdateDTO GetProductUpdateById(string id);
        void UpdateProduct(string id, ProductUpdateDTO productUpdateDto);

        // Remove 
        ProductRemove  GetProductRemoveById(string id);
        
        void ProductRemoveById(string id);
        // Home 
        List<RecentProductDTO> RecentProductList(string langcide);
        List<DiscountProductDTO> discountProduct(string langcide);






    }
}
