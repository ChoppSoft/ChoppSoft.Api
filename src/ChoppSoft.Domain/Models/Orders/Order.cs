using ChoppSoft.Domain.Models.Customers;
using ChoppSoft.Domain.Models.Orders.Enums;
using ChoppSoft.Domain.Models.Orders.Items;
using ChoppSoft.Infra.Bases;
using ChoppSoft.Infra.Extensions;

namespace ChoppSoft.Domain.Models.Orders
{
    public sealed class Order : Entity
    {
        public Order(Guid customerId, 
                     DateTime? deliveryDate)
        {
            CustomerId = customerId;
            DeliveryDate = deliveryDate;
            Status = EnumOrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        public Order() { }

        public Guid CustomerId { get; private set; }
        public DateTime? DeliveryDate  { get; private set; }
        public EnumOrderStatus Status { get; private set; }
        public decimal TotalAmount { get; private set; }
        public bool Shipped { get; private set; } = false;
        public bool Delivered { get; private set; } = false;
        public bool Paid { get; private set; } = false;

        public Customer Customer { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }

        internal void ChangeCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }

        internal void ChangeDeliveryDate(DateTime? deliveryDate)
        {
            DeliveryDate = deliveryDate;
        }

        internal void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        internal void RemoveItem(OrderItem item)
        {
            Items.Remove(item); 
        }

        internal void AddItems(ICollection<OrderItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        internal void RemoveItems(ICollection<OrderItem> items)
        {
            foreach (var item in items)
            {
                RemoveItem(item);
            }
        }

        internal void Totalizing()
        {
            TotalAmount = Items.Sum(p => p.TotalPrice).ToMonetary();
        }

        internal void MakeAsConfirmed()
        {
            Status = EnumOrderStatus.Confirmed;
        }

        internal void MakeAsCanceled()
        {
            Status = EnumOrderStatus.Cancelled;
        }

        internal void UndoConfirme()
        {
            Status = EnumOrderStatus.Processing;
        }

        internal void MakeAsShipped()
        {
            Shipped = true;
        }

        internal void UndoShipped()
        {
            Shipped = false;
        }

        internal void MakeAsDelivered()
        {
            Delivered = true;
        }

        internal void UndoDelivered()
        {
            Delivered = false;
        }

        internal void MakeAsPaid() 
        {
            Paid = true;
        }

        internal void UndoPaid()
        {
            Paid = false;
        }
    }
}
