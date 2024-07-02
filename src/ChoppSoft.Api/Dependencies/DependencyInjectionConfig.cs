﻿using ChoppSoft.Domain.Interfaces.Addresses;
using ChoppSoft.Domain.Interfaces.Customers;
using ChoppSoft.Domain.Interfaces.Products;
using ChoppSoft.Domain.Interfaces.Resources;
using ChoppSoft.Domain.Interfaces.Suppliers;
using ChoppSoft.Domain.Interfaces.Users;
using ChoppSoft.Domain.Models.Addresses.Services;
using ChoppSoft.Domain.Models.Customers.Services;
using ChoppSoft.Domain.Models.Locations;
using ChoppSoft.Domain.Models.Products.Services;
using ChoppSoft.Domain.Models.Resources.Services;
using ChoppSoft.Domain.Models.Suppliers.Services;
using ChoppSoft.Domain.Models.Users.Services;
using ChoppSoft.Repository.Context;
using ChoppSoft.Repository.Repositories.Addresses;
using ChoppSoft.Repository.Repositories.Customers;
using ChoppSoft.Repository.Repositories.Products;
using ChoppSoft.Repository.Repositories.Resources;
using ChoppSoft.Repository.Repositories.Suppliers;
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

            services.AddScoped<IResourceService, ResourceService>();

            services.AddScoped<IResourceRepository, ResourceRepository>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ISupplierService, SupplierService>();

            services.AddScoped<ISupplierRepository, SupplierRepository>();

            return services;
        }
    }
}
