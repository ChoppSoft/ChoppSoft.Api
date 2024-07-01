using ChoppSoft.Domain.Interfaces.Users;
using ChoppSoft.Domain.Models.Locations;
using ChoppSoft.Domain.Models.Users.Services;
using ChoppSoft.Repository.Context;
using ChoppSoft.Repository.Repositories.Users;

namespace ChoppSoft.Api.Dependencies
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ILocationService, LocationService>();

            return services;
        }
    }
}
