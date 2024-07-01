using ChoppSoft.Domain.Interfaces.Addresses;
using ChoppSoft.Domain.Interfaces.Customers;
using ChoppSoft.Domain.Interfaces.Users;
using ChoppSoft.Domain.Models.Addresses.Services;
using ChoppSoft.Domain.Models.Customers.Services;
using ChoppSoft.Domain.Models.Locations;
using ChoppSoft.Domain.Models.Users.Services;
using ChoppSoft.Repository.Context;
using ChoppSoft.Repository.Repositories.Addresses;
using ChoppSoft.Repository.Repositories.Customers;
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

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IAddressService, AddressService>();

            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}
