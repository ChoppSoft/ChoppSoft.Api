using ChoppSoft.Domain.Interfaces.Addresses;
using ChoppSoft.Domain.Interfaces.Customers;
using ChoppSoft.Domain.Interfaces.Deliveries;
using ChoppSoft.Domain.Interfaces.Feedbacks;
using ChoppSoft.Domain.Interfaces.Inventories;
using ChoppSoft.Domain.Interfaces.Orders;
using ChoppSoft.Domain.Interfaces.Payments;
using ChoppSoft.Domain.Interfaces.Products;
using ChoppSoft.Domain.Interfaces.Resources;
using ChoppSoft.Domain.Interfaces.Routes;
using ChoppSoft.Domain.Interfaces.Suppliers;
using ChoppSoft.Domain.Interfaces.Users;
using ChoppSoft.Domain.Interfaces.Warehouses;
using ChoppSoft.Domain.Models.Addresses.Services;
using ChoppSoft.Domain.Models.Customers.Services;
using ChoppSoft.Domain.Models.Deliveries.Services;
using ChoppSoft.Domain.Models.Feedbacks.Services;
using ChoppSoft.Domain.Models.Inventories.Services;
using ChoppSoft.Domain.Models.Locations;
using ChoppSoft.Domain.Models.Orders.Services;
using ChoppSoft.Domain.Models.Payments.Services;
using ChoppSoft.Domain.Models.Products.Services;
using ChoppSoft.Domain.Models.Resources.Services;
using ChoppSoft.Domain.Models.Routes.Services;
using ChoppSoft.Domain.Models.Suppliers.Services;
using ChoppSoft.Domain.Models.Users.Services;
using ChoppSoft.Domain.Models.Warehouses.Services;
using ChoppSoft.Repository.Context;
using ChoppSoft.Repository.Repositories.Addresses;
using ChoppSoft.Repository.Repositories.Customers;
using ChoppSoft.Repository.Repositories.Deliveries;
using ChoppSoft.Repository.Repositories.Feedbacks;
using ChoppSoft.Repository.Repositories.Inventories;
using ChoppSoft.Repository.Repositories.Orders;
using ChoppSoft.Repository.Repositories.Payments;
using ChoppSoft.Repository.Repositories.Products;
using ChoppSoft.Repository.Repositories.Resources;
using ChoppSoft.Repository.Repositories.Routes;
using ChoppSoft.Repository.Repositories.Suppliers;
using ChoppSoft.Repository.Repositories.Users;
using ChoppSoft.Repository.Repositories.Warehouses;

namespace ChoppSoft.Api.Configurations
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

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IDeliveryService, DeliveryService>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteService, RouteService>();

            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IWarehouseService, WarehouseService>();

            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryService, InventoryService>();

            return services;
        }
    }
}
