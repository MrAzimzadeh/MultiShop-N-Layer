using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MultiShop.Core.DataAcces.MongoDB.Concrete;
using MultiShop.Core.DataAcces.MongoDB.MongoSettings;
using MultiShop.DataAcces.Abstract;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.DataAcces.Concrete.MongoDb
{
    public class MCategoryDal : MongoRepository<Category> , ICategoryDal
    {
        private readonly IMongoCollection<Category> _collection;
        public MCategoryDal(IDatabseSettings databseSettings) : base(databseSettings)
        {
            var database = new MongoClient(databseSettings.ConnectionString).GetDatabase(databseSettings.DatabaseName);
            _collection = database.GetCollection<Category>("category");
        }

        public List<ProductCategoryDTO> GetProductCategories()
        {
            var filter = Builders<Category>.Filter.ElemMatch(x => x.CategoryLanguages, x => x.LangCode == "Az");
            var category =  _collection.Find(filter).ToList();
            return new List<ProductCategoryDTO>();
        }
    }
}
