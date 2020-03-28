using CEDTeam.CES.Core.Configs;
using CEDTeam.CES.Core.Dtos.User;
using CEDTeam.CES.Core.Exceptions;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Web.Models.User;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Controllers.Api
{
    [Route("/api/v{version:apiVersion}/auth")]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IOptions<AppConfig> _appConfig;
        private readonly IUserService _userService;

        public AuthenticationController(IOptions<AppConfig> appConfig, IUserService userService)
        {
            _appConfig = appConfig;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var result = await _userService.GetUserLogin(new UserDto
            {
                Username = userName,
                Password = password
            }, User.GetUserID());
            if (result != null)
            {
                var claims = new List<Claim>();
                claims.AddRange(result.RoleList.Select(p => new Claim(ClaimTypes.Role, p.RoleID.ToString())));
                claims.AddRange(result.RightList.Select(p => new Claim("Rights", p.RightID.ToString())));
                claims.Add(new Claim("UserInfo", JsonConvert.SerializeObject(result)));
                IdentityOptions _options = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.Value.JWTKey)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                var userInfor = result.Adapt<UserModel>();
                userInfor.Roles = result.RoleList.Select(p => p.RoleID).ToList();
                userInfor.Rights = result.RightList.Select(p => p.RightID).ToList();
                return Ok(new { access_token = token, User = userInfor });
            }
            return BadRequest(new { message = "Username or password is incorrect." });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            return Ok(new { success = true });
        }
    }
}