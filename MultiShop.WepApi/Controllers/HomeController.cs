using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;

namespace MultiShop.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICategoryServices _categoryService;

        public HomeController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getcategories")]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetCategoryList("Az");
            return Ok(categories);
        }
    }
}
