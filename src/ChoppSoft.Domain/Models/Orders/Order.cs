using ChoppSoft.Domain.Models.Customers;
using ChoppSoft.Domain.Models.Orders.Enums;
using ChoppSoft.Domain.Models.Orders.Items;
using ChoppSoft.Domain.Models.Orders.Sservices.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Orders
{
    public sealed class Order : Entity
    {
        public Order(Guid customerId, 
                     DateTime? deliveryDate, 
                     EnumOrderStatus status, 
                     decimal totalAmount)
        {
            CustomerId = customerId;
            DeliveryDate = deliveryDate;
            Status = status;
            TotalAmount = totalAmount;
        }

        public Order() { }

        public Guid CustomerId { get; private set; }
        public DateTime? DeliveryDate  { get; private set; }
        public EnumOrderStatus Status { get; private set; }
        public decimal TotalAmount { get; private set; }

        public Customer Customer { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }

        internal void Update(OrderDto dto)
        {
            CustomerId = dto.customerid;
            DeliveryDate = dto.deliverydate;
            Status = dto.status;
            TotalAmount = dto.totalamount;
        }
    }
}
