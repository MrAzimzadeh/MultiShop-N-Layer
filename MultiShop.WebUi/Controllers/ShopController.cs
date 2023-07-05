using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;
using MultiShop.Entities.ViewModels;

namespace MultiShop.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductsServices _productService;
        private readonly ICategoryServices _categoryService;

        public ShopController(IProductsServices productService, ICategoryServices categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            var products = _productService.GetAllFilteredProductList("Az",0,null,null, true);

            ShopVM vm = new()
            {
                ProductList =  products,
                Categories= _categoryService.GetCategoriesByLanguage("Az")
            };

            return View(vm);
        }
    }
}