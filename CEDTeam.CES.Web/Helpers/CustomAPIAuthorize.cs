using CEDTeam.CES.Core.Enums;
using CEDTeam.CES.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace CEDTeam.CES.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true, Inherited = true)]
    public class CustomAPIAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private Right[] _rights;
        public CustomAPIAuthorizeAttribute()
        {

        }
        public CustomAPIAuthorizeAttribute(params Right[] rights)
        {
            _rights = rights;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated || (_rights != null && !context.HttpContext.User.IsInRight(_rights)))
            {
                context.HttpContext.Response.StatusCode = 404;
            }
        }
    }
}
