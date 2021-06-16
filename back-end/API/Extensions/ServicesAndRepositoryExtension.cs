using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Interfaces;

namespace Strijp_T_Hotspots.Extensions
{
    public static class ServicesAndRepositoryExtension
    {
        public static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHotspotRepository, HotspotRepository>();


            // Services
            services.AddScoped<IHotspotService, HotspotService>();
            services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
            services.AddScoped<IEncoder, Encoder>();
            services.AddScoped<IJWTHandler, JWTHandler>();
            services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();


            return services;
        }
    }
}
