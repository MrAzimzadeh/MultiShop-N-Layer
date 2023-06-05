using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;

namespace MultiShop.WebUI.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class ProductController : Controller
    {

        private readonly IProductsServices _productsServices;
        private  readonly  ICategoryServices _categoryServices;
        public ProductController(IProductsServices productsServices, ICategoryServices categoryServices)
        {
            _productsServices = productsServices;
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            var cats = _categoryServices.GetProductCategory();
            
            var products = _productsServices.GetProducts();
            return View(products);
        }
    }
}
