using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Business.Abstract;
using MultiShop.DataAcces.Abstract;
using MultiShop.DataAcces.Concrete.MongoDb;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.Category;

namespace MultiShop.Business.Concreate
{
    public class CategoryManager : ICategoryServices
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(CategoryCreateDTO categoryCreateDto)
        {
            List<CategoryLanguage> languages = new();
            foreach (var categoryLang in categoryCreateDto.CategoryLanguages)
            {
                CategoryLanguage language = new()
                {
                    LangCode = categoryLang.LangCode,
                    Name = categoryLang.Name,
                    SeoUrl = "lggjk"
                };
                languages.Add(language);
            }
            Category category = new()
            {
                PhotoUrl = categoryCreateDto.PhotoUrl,
                CategoryLanguages = languages,
            };
            _categoryDal.Add(category);
        }

        public List<Category> GetCategory()
        {
            return _categoryDal.GetAll();

        }

        public List<CategoryListDTO> GetCategoryList(string lang)
        {
            var categories = _categoryDal.GetAll();

            var result = categories.Select(x=> new CategoryListDTO
            {
                Id = x.Id,
                PhotoUrl = x.PhotoUrl,
                Name =  x.CategoryLanguages.FirstOrDefault(x=>x.LangCode == lang).Name,
                SeoUrl = x.CategoryLanguages.FirstOrDefault(x => x.LangCode == lang).SeoUrl,
                LangCode = x.CategoryLanguages.FirstOrDefault(x => x.LangCode == lang).LangCode,
                ProductCount = 0

            }).ToList();

            return result;
        }

        public Category GetCategoryById(string id)
        {
            var product = _categoryDal.Get(id);
            return product;
        }

        public void UpdateCategory(string id,CategoryCreateDTO updaCategoryDto)
        {
            List<CategoryLanguage> languages = new();
            foreach (var categoryLang in updaCategoryDto.CategoryLanguages)
            {
                CategoryLanguage language = new()
                {
                    LangCode = categoryLang.LangCode,
                    Name = categoryLang.Name,
                    SeoUrl = "lggjk"
                };
                languages.Add(language);
            }
            Category category = new()
            {
                PhotoUrl = updaCategoryDto.PhotoUrl,
                CategoryLanguages = languages,
            };


            _categoryDal.Update(id, category);
        }

        public void RemoveCategory(string id)
        {
             
             _categoryDal.Remove(id);

        }
    }
}
