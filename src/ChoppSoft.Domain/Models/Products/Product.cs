using ChoppSoft.Domain.Models.Products.Services.Dtos;
using ChoppSoft.Domain.Models.Suppliers;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Products
{
    public sealed class Product : Entity
    {
        public Product(string identifier, 
                       string description, 
                       string brand, 
                       double capacity, 
                       decimal price)
        {
            Identifier = identifier;
            Description = description;
            Brand = brand;
            Capacity = capacity;
            Price = price;

            Suppliers = new List<Supplier>();
        }

        public Product() { }

        public string Identifier { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public double Capacity { get; private set; }
        public decimal Price { get; private set; }

        public ICollection<Supplier> Suppliers { get; private set; }

        public void Update(ProductDto dto)
        {
            Identifier = dto.identifier;
            Description = dto.description;
            Brand = dto.brand;
            Capacity = dto.capacity;
            Price = dto.price;
        }
    }
}
