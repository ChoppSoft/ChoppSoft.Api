using ChoppSoft.Domain.Models.Suppliers;
using ChoppSoft.Domain.Models.Warehouses;

namespace ChoppSoft.Api.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Capacity { get; set; }
        public decimal Price { get; set; }
        public Guid? WarehouseId { get; set; }
        public string WarehouseDescription { get; set; }
        public bool Active { get; set; }
    }
}
