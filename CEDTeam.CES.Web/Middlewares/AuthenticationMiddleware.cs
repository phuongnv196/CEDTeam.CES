using CEDTeam.CES.Core.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<AppConfig> _config;

        public AuthenticationMiddleware(RequestDelegate next, IOptions<AppConfig> config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/User") && !("/".Equals(context.Request.Path) || context.Request.Path.StartsWithSegments("/Home")) && !context.User.Identity.IsAuthenticated)
            {
                context.Response.Redirect("../User");
            }
            await _next.Invoke(context);
        }
    }
}
