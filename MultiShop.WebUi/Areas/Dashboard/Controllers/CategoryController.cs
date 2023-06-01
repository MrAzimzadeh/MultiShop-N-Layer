using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.Category;

namespace MultiShop.WebUi.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class CategoryController : Controller
    {
        private  readonly  ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateDTO categoryDto)
        {
            return RedirectToAction(nameof(Index));
        }
        
        
    }
}
