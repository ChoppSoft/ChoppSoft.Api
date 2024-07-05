using ChoppSoft.Domain.Models.Products;
using ChoppSoft.Domain.Models.Warehouses;

namespace ChoppSoft.Api.ViewModels
{
    public class InventoryViewModel
    {
        public double Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; }
        public Guid WarehouseId { get; set; }
        public string WarehouseDescription { get; set; }
    }
}
