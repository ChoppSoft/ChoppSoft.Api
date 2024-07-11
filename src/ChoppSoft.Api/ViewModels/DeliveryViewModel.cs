using ChoppSoft.Domain.Models.Deliveries.Enums;

namespace ChoppSoft.Api.ViewModels
{
    public class DeliveryViewModel
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ResourceId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public EnumDeliveryStatus Status { get; set; }

        public OrderViewModel Order { get; set; }
        public ResourceViewModel Resource { get; set; }
    }
}
