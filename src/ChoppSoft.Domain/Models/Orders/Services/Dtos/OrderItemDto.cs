namespace ChoppSoft.Domain.Models.Orders.Services.Dtos
{
    public record OrderItemDto(Guid productid,
                               decimal quantity,
                               decimal unitprice);
}
