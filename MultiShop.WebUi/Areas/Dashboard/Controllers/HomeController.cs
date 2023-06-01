using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
