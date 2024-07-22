using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Addresses;
using ChoppSoft.Domain.Models.Customers;
using ChoppSoft.Domain.Models.Deliveries;
using ChoppSoft.Domain.Models.Feedbacks;
using ChoppSoft.Domain.Models.Inventories;
using ChoppSoft.Domain.Models.Orders;
using ChoppSoft.Domain.Models.Orders.Items;
using ChoppSoft.Domain.Models.Payments;
using ChoppSoft.Domain.Models.Products;
using ChoppSoft.Domain.Models.Resources;
using ChoppSoft.Domain.Models.Suppliers;
using ChoppSoft.Domain.Models.Warehouses;

namespace ChoppSoft.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Address, AddressViewModel>()
                .ForMember(p => p.CustomerName, opt => opt.MapFrom(src => src.Customer.Name));

            CreateMap<Customer, CustomerViewModel>();

            CreateMap<Inventory, InventoryViewModel>()
                .ForMember(p => p.ProductDescription, opt => opt.MapFrom(src => src.Product.Description))
                .ForMember(p => p.WarehouseDescription, opt => opt.MapFrom(src => src.Warehouse.Description));

            CreateMap<Product, ProductViewModel>()
                .ForMember(p => p.WarehouseDescription, opt => opt.MapFrom(src => src.Warehouse.Description));

            CreateMap<Resource, ResourceViewModel>();

            CreateMap<Supplier, SupplierViewModel>();

            CreateMap<Warehouse, WarehouseViewModel>();

            CreateMap<Order,  OrderViewModel>()
                .ForMember(p => p.CustomerName, opt => opt.MapFrom(src => src.Customer.Name)); 

            CreateMap<Order, OrderWhitItemsViewModel>()
                .ForMember(p => p.CustomerName, opt => opt.MapFrom(src => src.Customer.Name)); 

            CreateMap<OrderItem, OrderItemViewModel>()
                .ForMember(p => p.ProductDescription, opt => opt.MapFrom(src => src.Product.Description));

            CreateMap<Feedback, FeedbackViewModel>();

            CreateMap<Delivery, DeliveryViewModel>();

            CreateMap<Route, RouteViewModel>();

            CreateMap<Payment, PaymentViewModel>();
        }
    }
}
