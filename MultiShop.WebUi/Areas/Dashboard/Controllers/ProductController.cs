using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;

namespace MultiShop.WebUI.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class ProductController : Controller
    {
        private readonly  IProductsServices _productsServices;

        public ProductController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
