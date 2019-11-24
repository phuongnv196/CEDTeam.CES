using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CEDTeam.CES.Web.Enums;

namespace CEDTeam.CES.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorize : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        readonly List<int> _roleRights = new List<int>();
        private readonly ResultEnum _resultEnum;
        public CustomAuthorize(ResultEnum resultEnum, params SecurityRightEnum[] roleRights)
        {
            _resultEnum = resultEnum;
            foreach (var item in roleRights)
            {
                _roleRights.Add((int)item);
            }
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var curentRoleRightString = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("UserRoleRight"))?.Value;
            var currentRoleRight = JsonConvert.DeserializeObject<List<int>>(string.IsNullOrWhiteSpace(curentRoleRightString) ? "" : curentRoleRightString)?.ToList();

            if (_roleRights.Any())
            {
                if (currentRoleRight != null && currentRoleRight.Any())
                {
                    var hasRoleRight = currentRoleRight.Where(x => _roleRights.Contains(x)).ToList();
                    if (!hasRoleRight.Any())
                    {
                        if (_resultEnum.Equals(ResultEnum.Json))
                            context.HttpContext.Response.StatusCode = 404;
                        else
                            context.HttpContext.Response.Redirect(_resultEnum.Equals(ResultEnum.PartialView) ? "/../Error/NoPermissionPartial" : "/../Error/NoPermission");
                    }
                }
            }
        }
    }
}
