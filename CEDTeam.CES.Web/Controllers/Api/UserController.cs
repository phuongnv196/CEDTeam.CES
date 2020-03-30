using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Constants;
using CEDTeam.CES.Core.Dtos.User;
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
    public class UserController : ControllerBase
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
        public async Task<IActionResult> Register(UserRegisterModel user)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  {
            if(ModelState.IsValid)
            {
                var userDto = user.Adapt<UserDto>();
                userDto.SelectedRoles = new List<int> { (int)Role.Member};
                var result = await _userService.InsertUser(userDto, AppConstant.SYSTEM_ID);
                if(result.Success)
                {
                    _emailService.SendEmailActivateUser(user.FirstName, user.Email, result.Result.ActivateKey);
                } 
                else
                {
                    switch(result.ReturnValue)
                    {
                        case -1:
                            result.ErrorMessage = AppConstant.ErrorMessage.USERNAME_EXIST;
                            break;
                        case -2:
                            result.ErrorMessage = AppConstant.ErrorMessage.EMAIL_EXIST;
                            break;
                    }    
                }
                return new ObjectResult(result);
            } 
            else
            {
                return new ObjectResult(ModelState.ToList());
            }
        }

        [HttpGet]
        [Route("active-user")]
        public async Task<IActionResult> ActiveUser(string activateKey)
        {
            var result = (await _userService.ActivateUser(activateKey));
            if (!result.Success)
            {
                result.ErrorMessage = AppConstant.ErrorMessage.ERROR_ACTIVATE_USER;
            }
            return new ObjectResult(result);
        }

        [HttpPost]
        [Route("get-users")]
        public async Task<IActionResult> GetUsers(string searchString)
        {
            return new ObjectResult((await _userService.GetListUser(searchString, User.GetUserID())).Adapt<List<UserModel>>());
        }
    }
}