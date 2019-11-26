using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CEDTeam.CES.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {

        public CustomAuthorize()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("User"))?.Value;
            if (user != "admin")
                context.HttpContext.Response.Redirect("../User");
        }
    }
}
