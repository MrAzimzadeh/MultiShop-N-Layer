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