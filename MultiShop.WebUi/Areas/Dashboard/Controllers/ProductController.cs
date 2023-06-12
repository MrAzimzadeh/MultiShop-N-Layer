using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Business.Abstract;
using MultiShop.Entities.DTOs.ProductDTOs;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MultiShop.Entities.Concreate;
using ZstdSharp.Unsafe;
using System.IO;

namespace MultiShop.WebUI.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class ProductController : Controller
    {

        private readonly IProductsServices _productsServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IWebHostEnvironment _env;
        public ProductController(IProductsServices productsServices, ICategoryServices categoryServices, IWebHostEnvironment env)
        {
            _productsServices = productsServices;
            _categoryServices = categoryServices;
            _env = env;
        }

        public IActionResult Index()
        {
            var cats = _categoryServices.GetCategoriesByLanguage("Az");
            var products = _productsServices.GetDashboardProducts("Az");
            return View(products);
        }

        #region Create




        public IActionResult Create()
        {
            var cats = _categoryServices.GetCategoryList("Az");
            ViewBag.Category = new SelectList(cats, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateDTO productCreateDto, List<string> categoryId, List<IFormFile> photo)
        {
            try
            {
                List<string> photos = new();
                var cats = _categoryServices.GetCategoryList("Az");
                ViewBag.Category = new SelectList(cats, "Id", "Name");
                productCreateDto.Categories = categoryId;
                for (int i = 0; i < photo.Count; i++)
                {
                    var path = "/Upload/" + Guid.NewGuid() + Path.GetExtension(photo[i].FileName);
                    using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                    {
                        photo[i].CopyTo(fileStream);
                    }
                    photos.Add(path);
                }
                productCreateDto.PhotoUrl = photos;
                if (categoryId.Count == 0)
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
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var delete = _productsServices.GetProductRemoveById(id);
            ViewBag.name = delete.ProductLanguage[0].Name;
            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(string id, Product product)
        {

            _productsServices.ProductRemoveById(id);

            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region  Edit



        [HttpGet]
        public IActionResult Edit(string id)
        {
            var cats = _categoryServices.GetCategoryList("Az");
            ViewData["Category"] = cats;
            var update = _productsServices.GetProductUpdateById(id);
            return View(update);
        }

        [HttpPost]
        public IActionResult Edit(string id, ProductUpdateDTO product, List<string> categoryId)
        {
            var prosuctId = _productsServices.GetProductUpdateById(id);


            _productsServices.UpdateProduct(id, product);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail

        public IActionResult Detail(string id)
        {
            var categories = _categoryServices.GetCategoriesByLanguage("Az");
            var detail = _productsServices.GetProductById(id);
            List<string> categoriList = new();
            foreach (var cat in categories)
            {
                var result = detail.Categories.Contains(cat.Id);
                if (result) categoriList.Add(cat.Name);
            }
            ViewData["Categories"] = categoriList;
            return View(detail);
        }


        #endregion


    }
}
