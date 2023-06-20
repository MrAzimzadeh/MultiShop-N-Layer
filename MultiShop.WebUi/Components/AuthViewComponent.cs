using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;
using MultiShop.Core.Entities.Concreate;

namespace MultiShop.WebUI.Components
{
    public class AuthViewComponent : ViewComponent
    {
        private  readonly  UserManager<User> _userManager;
        private  readonly  IHttpContextAccessor _contextAccessor;

        public AuthViewComponent(UserManager<User> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);
            var viewResult = View(viewName: "Default", model: user);
            return await Task.FromResult<IViewComponentResult>(viewResult);
        }
    }
}
