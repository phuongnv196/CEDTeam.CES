using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Web.Models.User;
using Mapster;
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
            return new ObjectResult(await _userService.Get());
        }
        public async Task<IActionResult> Insert()
        {
            var user = new UserModel();
            await _userService.Insert(user.Adapt<UserDto>());
            return new ObjectResult("");
        }
    }
}