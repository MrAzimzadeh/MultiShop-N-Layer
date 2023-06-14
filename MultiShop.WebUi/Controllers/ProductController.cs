using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiShop.Business.Abstract;

namespace MultiShop.WebUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductsServices _productSercice;


        public ProductController(ILogger<ProductController> logger, IProductsServices productSercice)
        {
            _logger = logger;
            _productSercice = productSercice;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(string id)
        {
            var detailProduct = _productSercice.GetDetailByIdLangCode(id, "Az");
            return View(detailProduct);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}