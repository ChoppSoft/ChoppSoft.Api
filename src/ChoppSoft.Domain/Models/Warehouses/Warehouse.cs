using ChoppSoft.Domain.Models.Products;
using ChoppSoft.Domain.Models.Warehouses.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Warehouses
{
    public sealed class Warehouse : Entity
    {
        public Warehouse(string description, 
                         string location)
        {
            Description = description;
            Location = location;
            Products = new List<Product>();
        }

        public Warehouse() { }

        public string Description { get; private set; }
        public string Location { get; private set; }

        public ICollection<Product> Products { get; private set; }

        internal void Update(WarehouseDto dto)
        {
            Description = dto.description;
            Location = dto.location;
        }

        internal void AddProduct(Product product) => Products.Add(product);

        internal void AddProducts(ICollection<Product> products)
        {
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
    }
}
