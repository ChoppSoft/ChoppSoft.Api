using ChoppSoft.Domain.Models.Products;

namespace ChoppSoft.Api.ViewModels
{
    public class WarehouseViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool Active { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
