using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MultiShop.Business.Abstract;
using MultiShop.DataAcces.Abstract;
using MultiShop.DataAcces.Concrete.MongoDb;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.Category;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.Business.Concreate
{
    public class CategoryManager : ICategoryServices
    {
        private readonly ICategoryDal _categoryDal;
        private  readonly  IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
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

        public CategoryCreateDTO GetCategoryById(string id)
        {
            var category = _categoryDal.Get(id);

            CategoryCreateDTO categoryCreateDto = new()
            {
                PhotoUrl = category.PhotoUrl,
                CategoryLanguages = category.CategoryLanguages
            };
            
            return categoryCreateDto;
        }

        public CategoryUpdateDTO GetUpdatedCategoryById(string id)
        {
            var category = _categoryDal.Get(id);

            CategoryUpdateDTO categoryCreateDto = new()
            {
                Id = id,
                PhotoUrl = category.PhotoUrl,
                CategoryLanguages = category.CategoryLanguages
            };

            return categoryCreateDto;
        }

        public CategoryRemove GetRemoveCategoryById(string id)
        {
            var category = _categoryDal.Get(id);


            CategoryRemove categoryCreateDto = new()
            {
                Id = id ,
                PhotoUrl = category.PhotoUrl,
                CategoryLanguages = category.CategoryLanguages,
                
            };

            return categoryCreateDto;
        }

        public void UpdateCategory(string id,CategoryUpdateDTO updaCategoryDto)
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
                Id = id,
                PhotoUrl = updaCategoryDto.PhotoUrl,
                CategoryLanguages = languages,
            };


            _categoryDal.Update(id, category);
        }

        public void RemoveCategory(string id)
        {
             
             _categoryDal.Remove(id);

        }

        public CategoryDetailDTO GetDetailById(string id)
        {
            var detail = _categoryDal.Get(id);
            List<CategoryLanguage> languages = new();
            foreach (var categoryLang in detail.CategoryLanguages)
            {
                CategoryLanguage language = new()
                {
                    LangCode = categoryLang.LangCode,
                    Name = categoryLang.Name,
                    SeoUrl = "lggjk"
                };
                languages.Add(language);
            }
            CategoryDetailDTO category = new()
            {
                Id = id,
                PhotoUrl = detail.PhotoUrl,
                CategoryLanguages = languages,
            };

            return category;

        }

   

        public List<CategoryListDTO>  GetCategoriesByLanguage(string lang)
        {
            var categories = _categoryDal.GetAll();

            var result = categories.Select(x => new CategoryListDTO
            {
                Id = x.Id, 
                Name = x.CategoryLanguages.FirstOrDefault(z => z.LangCode == lang).Name,
                LangCode = lang,
                PhotoUrl = x.PhotoUrl,
                SeoUrl = x.CategoryLanguages.FirstOrDefault(z => z.LangCode == lang).SeoUrl,
                ProductCount = 0
            }).ToList();
             
            return result;

        }
    }
}
