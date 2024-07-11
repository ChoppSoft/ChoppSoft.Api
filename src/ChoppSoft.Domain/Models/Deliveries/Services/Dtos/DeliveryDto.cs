using ChoppSoft.Domain.Models.Deliveries.Enums;

namespace ChoppSoft.Domain.Models.Deliveries.Services.Dtos
{
    public record DeliveryDto(Guid orderid,
                              Guid resourceid,
                              DateTime scheduleddate,
                              DateTime? deliverydate);
}
