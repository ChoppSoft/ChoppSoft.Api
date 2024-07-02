using ChoppSoft.Domain.Models.Orders.Enums;

namespace ChoppSoft.Domain.Models.Orders.Sservices.Dtos
{
    public record OrderDto(Guid customerid,
                           DateTime? deliverydate,
                           EnumOrderStatus status,
                           decimal totalamount);
}
