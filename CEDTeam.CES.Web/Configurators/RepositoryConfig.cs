using Microsoft.Extensions.DependencyInjection;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Infrastructure.Repositories;

namespace CEDTeam.CES.Web.Configurators
{
    public static class RepositoryConfig
    {
        public static void ConfigRepository(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
