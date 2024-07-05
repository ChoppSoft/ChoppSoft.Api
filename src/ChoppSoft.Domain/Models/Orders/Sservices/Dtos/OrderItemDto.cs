namespace ChoppSoft.Domain.Models.Orders.Sservices.Dtos
{
    public record OrderItemDto(Guid orderid,
                               Guid productid,
                               decimal quantity,
                               decimal unitprice);    
}
