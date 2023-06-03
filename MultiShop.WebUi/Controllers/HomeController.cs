using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Models;
using System.Diagnostics;
using MultiShop.Business.Abstract;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs;
using MultiShop.Entities.ViewModels;

namespace MultiShop.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsServices _productServices;
        private readonly  ICategoryServices _categoryServices;
        public HomeController(ILogger<HomeController> logger, IProductsServices productServices, ICategoryServices categoryServices)
        {
            _logger = logger;
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            var categories = _categoryServices.GetCategoryList("Az");

            HomeVM vm = new()
            {
                CategoryList = categories
            };
            return View(vm);
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