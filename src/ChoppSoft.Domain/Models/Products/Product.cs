using ChoppSoft.Domain.Models.Products.Services.Dtos;
using ChoppSoft.Domain.Models.Suppliers;
using ChoppSoft.Domain.Models.Warehouses;
using ChoppSoft.Infra.Bases;
using ChoppSoft.Infra.Extensions;

namespace ChoppSoft.Domain.Models.Products
{
    public sealed class Product : Entity
    {
        public Product(string identifier,
                       string description,
                       string brand,
                       decimal capacity,
                       decimal price,
                       decimal cost)
        {
            Identifier = identifier;
            Description = description;
            Brand = brand;
            Capacity = capacity;
            Price = price.ToMonetary();
            Cost = cost.ToMonetary();
            Profit = (Price - Cost).ToMonetary();
            Margin = ((Profit / Price) * 100).ToMonetary();

            Suppliers = new List<Supplier>();
        }

        public Product() { }

        public string Identifier { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public decimal Capacity { get; private set; }
        public decimal Price { get; private set; }
        public decimal Cost { get; private set; }
        public decimal Profit { get; private set; }
        public decimal Margin { get; private set; }
        public Guid? WarehouseId { get; private set; }

        public Warehouse Warehouse { get; private set; }
        public ICollection<Supplier> Suppliers { get; private set; }

        internal void Update(ProductDto dto)
        {
            Identifier = dto.identifier;
            Description = dto.description;
            Brand = dto.brand;
            Capacity = dto.capacity;
            Price = dto.price.ToMonetary();
            Cost = dto.cost.ToMonetary();
            Profit = (Price - Cost).ToMonetary();
            Margin = ((Profit / Price) * 100).ToMonetary();
        }
    }
}
