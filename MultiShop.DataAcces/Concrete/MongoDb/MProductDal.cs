using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Core.DataAcces.MongoDB.Concrete;
using MultiShop.Core.DataAcces.MongoDB.MongoSettings;
using MultiShop.DataAcces.Abstract;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.DataAcces.Concrete.MongoDb
{
    public class MProductDal : MongoRepository<Product>, IProductDal
    {
        private readonly IMongoCollection<Product> _collection;
        private readonly ICategoryDal _categoryDal;
        public MProductDal(IDatabseSettings databaseSettings, ICategoryDal categoryDal) : base(databaseSettings)
        {
            var database = new MongoClient(databaseSettings.ConnectionString).GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Product>("products");
            _categoryDal = categoryDal;
        }

        public List<ProductListDTO> GetProductByLanguage(string langcode)
        {
            var product = _collection.Find(FilterDefinition<Product>.Empty).ToList();
            var result = product.Select(x => new ProductListDTO
            {
                Id = x.Id,
                Name = x.ProductLanguages.FirstOrDefault(z => z.LangCode == langcode).Name,
                PhotoUrl = x.PhotoUrl,
                Price = x.Price,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                Categories = _categoryDal.GetCategoriesByLanguage(langcode, x.Categories)
            }).ToList();
            return result;
        }

        public List<RecentProductDTO> RecentProduct(string langcide)
        {
            var product = _collection.Find(FilterDefinition<Product>.Empty).ToList();
            var result = product.Select(x => new RecentProductDTO
            {
                Id = x.Id,
                Discount = x.Discount,
                Name = x.ProductLanguages.FirstOrDefault(z => z.LangCode == langcide).Name,
                PhotoUrl = x.PhotoUrl.FirstOrDefault(),
                Price = x.Price,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                Categories = _categoryDal.GetCategoriesByLanguage(langcide, x.Categories)
            }).OrderByDescending(x => x.Id).ToList();
            return result;
        }

        public List<DiscountProductDTO> DiscountProduct(string langcide)
        {
            var product = _collection.Find(FilterDefinition<Product>.Empty).ToList();
            var result = product.Select(x => new DiscountProductDTO
            {
                Id = x.Id,
                Discount = x.Discount,
                Name = x.ProductLanguages.FirstOrDefault(z => z.LangCode == langcide).Name,
                PhotoUrl = x.PhotoUrl.FirstOrDefault(),
                Price = x.Price,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                Categories = _categoryDal.GetCategoriesByLanguage(langcide, x.Categories)
            }).Where(x => x.Discount > 0).OrderByDescending(x => x.Id).ToList();
            return result;
        }

        public ProductDetail GetProductDetail(string id, string lang)
        {

            var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id));
            
            var result = _collection.Find(filter).FirstOrDefault();
            
            ProductDetail detail = new()
            {
                Name = result.ProductLanguages.FirstOrDefault(x => x.LangCode == lang).Name,
                Categories = result.Categories,
                PhotoUrl = result.PhotoUrl,
                Price = result.Price,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                LangCode = result.ProductLanguages.FirstOrDefault(x => x.LangCode == lang).LangCode,
                CreatedDate = result.CreatedDate,
                Description = result.ProductLanguages.FirstOrDefault(x => x.LangCode == lang).Description,
                Discount = result.Discount,
                DiscountEndDate = result.DiscountEndDate,
                Id = result.Id,
                SeoUrl = result.ProductLanguages.FirstOrDefault(x => x.LangCode == lang).SeoUrl,
                UpdatedDate = result.UpdatedDate

            };
            //var result = product.Select(x => new ProductDetail
            //{
            //    Id = id,
            //    Name = x.ProductLanguages.FirstOrDefault(z => z.LangCode == lang).Name,
            //    PhotoUrl = x.PhotoUrl,
            //    Price = x.Price,
            //    IsActive = x.IsActive,
            //    IsDeleted = x.IsDeleted,
            //    Categories = _categoryDal.GetCategoriesByLanguage(lang, x.Categories)
            //}).FirstOrDefault();
            return detail;
        }

        public List<RecentProductDTO> FilterProducts(string langcode, decimal? minPrice, decimal? maxPrice, string? categoryId, bool IsDiscounted, int page)
        {
            var product = _collection.Find(FilterDefinition<Product>.Empty).ToList();
            var result = product.Select(x => new RecentProductDTO
            {
                Id = x.Id,
                Discount = x.Discount,
                Name = x.ProductLanguages.FirstOrDefault(z => z.LangCode == langcode).Name,
                PhotoUrl = x.PhotoUrl[0],
                Price = x.Price,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                Categories = x.Categories
            }).Skip(page).Take(10).OrderByDescending(x => x.Id).ToList();
            minPrice = minPrice == null ? 0 : minPrice;
            maxPrice = maxPrice == null ? result.OrderByDescending(x => x.Price).First().Price : maxPrice;
            var skipFilter = page;

            var test = result.FirstOrDefault().Categories;

            if (categoryId == null)
            {
                return result.Where(x => x.Price > minPrice && x.Price <= maxPrice).ToList();

            }
            var filter = result.Where(x => x.Price > minPrice && x.Price < maxPrice && x.Categories.Contains(categoryId)).ToList();
            return filter;

        }
    }
}
