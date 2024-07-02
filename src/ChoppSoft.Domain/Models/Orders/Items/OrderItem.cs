using ChoppSoft.Domain.Models.Orders.Sservices.Dtos;
using ChoppSoft.Domain.Models.Products;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Orders.Items
{
    public sealed class OrderItem : Entity
    {
        public OrderItem(Guid orderId, 
                         Guid productId, 
                         double quantity, 
                         decimal unitPrice, 
                         decimal totalPrice)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public OrderItem() { }

        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public double Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

        public void Update(OrderItemDto dto)
        {
            OrderId = dto.orderid;
            ProductId = dto.productid;
            Quantity = dto.quantity;
            UnitPrice = dto.unitprice;
            TotalPrice = dto.totalprice;
        }
    }
}
