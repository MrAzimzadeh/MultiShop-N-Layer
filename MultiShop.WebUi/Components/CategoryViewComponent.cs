using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;

namespace MultiShop.WebUI.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryViewComponent(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _categoryServices.GetCategoriesByLanguage("Az");
            var viewResult = View(viewName: "Default", model: categories);
            return await Task.FromResult<IViewComponentResult>(viewResult);
        }


    }
}