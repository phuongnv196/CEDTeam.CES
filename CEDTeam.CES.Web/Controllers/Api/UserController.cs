using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Enums;
using CEDTeam.CES.Core.Exceptions;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Core.Interfaces.Services;
using CEDTeam.CES.Web.Helpers;
using CEDTeam.CES.Web.Models.User;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers.Api
{
    [Route("/api/v{version:apiVersion}/user")]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class UserController : BaseAPIController
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        public UserController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserRegisterModel user)
        {
            if(ModelState.IsValid)
            {
                //_userService.
                _emailService.SendEmailWellcome(user.Email);
                return new ObjectResult(new { sucess = true });
            } 
            else
            {
                return new ObjectResult(ModelState.ToList());
            }
        }
        
        [HttpPost]
        [Route("get-users")]
        public async Task<IActionResult> GetUsers(string searchString)
        {
            return new ObjectResult((await _userService.GetListUser(searchString, User.GetUserID())).Adapt<List<UserModel>>());
        }
    }
}