using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Entities.DTOs.Category;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.Business.Abstract
{
    public interface ICategoryServices
    {
        void AddCategory(CategoryCreateDTO categoryCreateDto);
        List<Category> GetCategory();
        List<CategoryListDTO> GetCategoryList(string lang);
        CategoryCreateDTO GetCategoryById(string id);
        CategoryUpdateDTO GetUpdatedCategoryById(string id);
        CategoryRemove GetRemoveCategoryById(string id);
        void UpdateCategory(string id, CategoryUpdateDTO updaCategoryDto);
        void RemoveCategory(string id);
        // Detail 
        CategoryDetailDTO GetDetailById(string id);
        List<CategoryListDTO> GetCategoriesByLanguage(string lang);
    }
}
