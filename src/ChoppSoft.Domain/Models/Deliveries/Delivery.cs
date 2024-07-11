using ChoppSoft.Domain.Models.Deliveries.Enums;
using ChoppSoft.Domain.Models.Deliveries.Services.Dtos;
using ChoppSoft.Domain.Models.Orders;
using ChoppSoft.Domain.Models.Resources;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Deliveries
{
    public sealed class Delivery : Entity
    {
        public Delivery(Guid orderId, 
                        Guid resourceId, 
                        DateTime scheduledDate, 
                        DateTime? deliveryDate)
        {
            OrderId = orderId;
            ResourceId = resourceId;
            ScheduledDate = scheduledDate;
            DeliveryDate = deliveryDate;
        }

        public Delivery() { }

        public Guid OrderId { get; private set; }
        public Guid ResourceId { get; private set; }
        public DateTime ScheduledDate { get; private set; }
        public DateTime? DeliveryDate { get; private set; }
        public EnumDeliveryStatus Status { get; private set; }

        public Order Order { get; private set; }
        public Resource Resource { get; private set; }

        internal void Update(DeliveryDto dto)
        {
            OrderId = dto.orderid;
            ResourceId = dto.resourceid;
            ScheduledDate = dto.scheduleddate;
            DeliveryDate = dto.deliverydate;
        }
    }
}
