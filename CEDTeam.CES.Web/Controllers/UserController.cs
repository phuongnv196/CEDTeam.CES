using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Web.Models.User;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(UserModel model)
        {
            if(model != null && model.Username != null && model.Username.ToLower().Equals("admin") && model.Password.Equals("admin123"))
            {
                var claims = new List<Claim>
                {
                    new Claim("User", "admin")
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                User.AddIdentity(identity);
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), new AuthenticationProperties { });
                return Redirect("../product-manager");
            }
            if(model != null && model.Username == null)
            {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng!";
            }
            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("../");
        }
        public async Task<IActionResult> Insert()
        {
            var user = new UserModel();
            await _userService.Insert(user.Adapt<UserDto>());
            return new ObjectResult("");
        }
    }
}