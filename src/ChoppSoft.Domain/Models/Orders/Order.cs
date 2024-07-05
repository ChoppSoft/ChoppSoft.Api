﻿using ChoppSoft.Domain.Models.Customers;
using ChoppSoft.Domain.Models.Orders.Enums;
using ChoppSoft.Domain.Models.Orders.Items;
using ChoppSoft.Domain.Models.Orders.Sservices.Dtos;
using ChoppSoft.Infra.Bases;

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
    }
}