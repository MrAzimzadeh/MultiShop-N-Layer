using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Entities.DTOs.Category;

namespace MultiShop.Business.Abstract
{
    public interface ICategoryServices
    {
        void AddCategory(CategoryCreateDTO categoryCreateDto);
        List<Category> GetCategory();
        List<CategoryListDTO> GetCategoryList(string lang);
        Category GetCategoryById(string id);
        void UpdateCategory(string id,CategoryCreateDTO updaCategoryDto);
        void RemoveCategory(string id);
    }
}
