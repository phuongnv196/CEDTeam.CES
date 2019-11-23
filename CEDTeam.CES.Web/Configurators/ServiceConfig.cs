using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Infrastructure.Implements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Configurators
{
    public static class ServiceConfig
    {
        public static void ConfigService(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
