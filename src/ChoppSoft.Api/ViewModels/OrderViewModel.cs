using ChoppSoft.Domain.Models.Orders.Enums;

namespace ChoppSoft.Api.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public EnumOrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Shipped { get; set; }
        public bool Delivered { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
