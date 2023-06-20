using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Core.Entities.Concreate;
using MultiShop.Core.Helpers;
using MultiShop.Entities.DTOs.UserDTOs;

namespace MultiShop.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
          
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid) //todo Bosluqu Yoxlayiriq
            {
                return View(loginDTO);
            }
            var checkEmail = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (checkEmail == null)
            {
                ViewBag.Error = "This Email Is not exist! "; // 
                return View();
            }
            Microsoft
                .AspNetCore
                .Identity
                .SignInResult
                result =
                    await _signInManager
                        .PasswordSignInAsync(
                            checkEmail,
                            loginDTO.Password,
                            isPersistent: loginDTO.RememberMe,
                            lockoutOnFailure: true
                        );

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Error", "Email or Password is invalid!!!");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDTO);
            }

            var checkEmail = await _userManager.FindByEmailAsync(registerDTO.Email);
            if (checkEmail != null)
            {
                return View();
            }
            var userToken = Guid.NewGuid().ToString();
            User newUser = new()
            {
                UserName = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PhotoUrl = "/uploads/avatar.png",
                BirthDay = DateTime.Now,
                UserToken = userToken
            };
            var result = await _userManager.CreateAsync(newUser, registerDTO.Password);
            if (result.Succeeded)
            {
                //EmaillHelper _emaillHelper = new EmaillHelper();
                //_emaillHelper.SendConfirmationEmail(newUser.Email , newUser.UserToken , newUser.FirstName , newUser.LastName);
                

                return View(nameof(Login));
            }
            else
            {
                return View(registerDTO);
            }


        }

        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user.UserToken == token)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login");
            }
            else
            {
                return NotFound();
            }
        }


    }
}
