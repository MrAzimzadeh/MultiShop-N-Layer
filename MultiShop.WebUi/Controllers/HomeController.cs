using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Models;
using System.Diagnostics;
using MultiShop.Business.Abstract;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs;

namespace MultiShop.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsServices _productServices;
        public HomeController(ILogger<HomeController> logger, IProductsServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        public IActionResult Index()
        {

            List<ProductLanguageDTO> productLanguagesDTO = new()
            {

            };
            ProductLanguageDTO languageAz = new()
            {
                Name = "salam",
                Description = "Sagol",
                LangCode = "Az"
            };
            ProductLanguageDTO languageEn = new()
            {
                Name = "Hello",
                Description = "About",
                LangCode = "En"
            };
            productLanguagesDTO.Add(languageAz);
            productLanguagesDTO.Add(languageEn);
            ProductCreateDTO productCreateDto = new()
            {
                ProductLanguages = productLanguagesDTO,
                Categories = new List<string>()
                {
                    "Test 1" , "Test 2"
                },
                PhotoUrl = new List<string>()
                {
                    "img.1" , "immg.2"
                },
                Discount = 10.2M,
                Price = 100,
                DiscountEndDate = DateTime.Now
            };
            _productServices.AddProduct(productCreateDto);
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}