using ChoppSoft.Domain.Models.Orders.Enums;

namespace ChoppSoft.Domain.Models.Orders.Services.Dtos
{
    public record OrderDto(Guid customerid,
                           DateTime? deliveryDate);
}
