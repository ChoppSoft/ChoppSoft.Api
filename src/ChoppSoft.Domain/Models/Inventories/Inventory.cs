using ChoppSoft.Domain.Models.Inventories.Services.Dtos;
using ChoppSoft.Domain.Models.Products;
using ChoppSoft.Domain.Models.Warehouses;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Inventories
{
    public sealed class Inventory : Entity
    {
        public Inventory(Guid productId, 
                         Guid warehouseId, 
                         double quantity, 
                         DateTime lastUpdated)
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            Quantity = quantity;
            LastUpdated = DateTime.UtcNow;
        }

        public Inventory() { }

        public Guid ProductId { get; private set; }
        public Guid WarehouseId { get; private set; }
        public double Quantity { get; private set; }
        public DateTime LastUpdated { get; private set; }

        public Product Product { get; private set; }
        public Warehouse Warehouse { get; private set; }

        public void Update(InventoryDto dto)
        {
            ProductId = dto.productid;
            WarehouseId = dto.warehouseid;
            Quantity = dto.quantity;
            LastUpdated = DateTime.UtcNow;
        }
    }
}
