using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Business.Abstract;
using MultiShop.Entities.DTOs.ProductDTOs;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace MultiShop.WebUI.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class ProductController : Controller
    {

        private readonly IProductsServices _productsServices;
        private readonly ICategoryServices _categoryServices;
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

        public IActionResult Create()
        {
            var cats = _categoryServices.GetCategoryList("Az");
            ViewBag.Category = new SelectList(cats, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateDTO productCreateDto, List<string> categoryId)
        {
            try
            {
                var cats = _categoryServices.GetCategoryList("Az");
                ViewBag.Category = new SelectList(cats, "Id", "Name");
                productCreateDto.Categories = categoryId;
                if (!ModelState.IsValid)
                {
                    ViewBag.Error = "Empty";
                    return View(productCreateDto);
                }

                if (categoryId.Count  == 0)
                {
                    ViewBag.Error = "Ged Categorya Sec";
                    return View(productCreateDto);
                }

                _productsServices.AddProduct(productCreateDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(productCreateDto);

            }

        }
    }
}
