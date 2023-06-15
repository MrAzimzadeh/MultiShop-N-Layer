using Microsoft.AspNetCore.Mvc;
using MultiShop.Entities.DTOs.UserDTOs;

namespace MultiShop.WebUI.Controllers
{
    public class AuthController : Controller
    {
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            return View();
        }
    }
}
