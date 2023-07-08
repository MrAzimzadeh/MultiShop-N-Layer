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
    public class MCategoryDal : MongoRepository<Category>, ICategoryDal
    {

        private readonly IMongoCollection<Category> _collection;
        public MCategoryDal(IDatabseSettings databaseSettings) : base(databaseSettings)
        {
            var database = new MongoClient(databaseSettings.ConnectionString).GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Category>("category");
        }

        public List<string> GetCategoriesByLanguage(string langcode, List<string> categoryId)
        {
            var categories = _collection.Find(FilterDefinition<Category>.Empty).ToList();

            var result = categories.Where(x => categoryId.Contains(x.Id)).Select(x => new
            {
                x.CategoryLanguages.FirstOrDefault(x => x.LangCode == langcode).Name
            }).Select(x => x.ToString()).ToList();
            return result;
        }

        public List<string> GetCategoriesById(string langcode, List<string> categoryId)
        {
            var categories = _collection.Find(FilterDefinition<Category>.Empty).ToList();

            var result = categories.Where(x => categoryId.Contains(x.Id)).Select(x => new
            {
                x.Id
            }).Select(x => x.ToString()).ToList();
            return result;
        }
    }

}

