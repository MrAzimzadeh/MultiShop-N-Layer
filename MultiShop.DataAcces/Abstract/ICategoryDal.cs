using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Core.DataAcces.MongoDB;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.DataAcces.Abstract
{
    public interface ICategoryDal :  IMongoRepository<Category>
    {
        List<string> GetCategoriesByLanguage(string langcode, List<string> categoryId);
        List<string> GetCategoriesById(string langcode, List<string> categories);
    }
}
