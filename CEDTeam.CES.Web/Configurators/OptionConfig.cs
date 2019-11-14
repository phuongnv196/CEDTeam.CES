using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CEDTeam.CES.Core.Configs;

namespace CEDTeam.CES.Web.Configurators
{
    public static class OptionConfig
    {
        public static void ConfigOptions(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<AppConfig>(_config.GetSection("AppConfig"));
        }
    }
}
