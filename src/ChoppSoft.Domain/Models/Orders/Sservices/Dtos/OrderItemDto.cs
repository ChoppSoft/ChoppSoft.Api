namespace ChoppSoft.Domain.Models.Orders.Sservices.Dtos
{
    public record OrderItemDto(Guid orderid,
                               Guid productid,
                               double quantity,
                               decimal unitprice,
                               decimal totalprice);    
}
