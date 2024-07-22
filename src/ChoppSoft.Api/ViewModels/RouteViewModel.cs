using ChoppSoft.Domain.Models.Addresses;
using ChoppSoft.Domain.Models.Resources;

namespace ChoppSoft.Api.ViewModels
{
    public class RouteViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ResourceId { get; set; }
        public bool Complete { get; set; }
        
        public Resource Resource { get; set; }
        public ICollection<AddressViewModel> Stops { get; set; }
        public ICollection<DeliveryViewModel> Deliveries { get; set; }
    }
}
