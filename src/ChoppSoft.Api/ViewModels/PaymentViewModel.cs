using ChoppSoft.Domain.Models.Payments.Enums;

namespace ChoppSoft.Api.ViewModels
{
    public class PaymentViewModel
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public EnumPaymentMethod Method { get; set; }
        public EnumTypeDiscount TypeDiscount { get; set; }
        public decimal Discount { get; set; }
        public EnumStatusPayment Status { get; set; }
        public decimal Expenses { get; set; }

        public OrderViewModel Order { get; set; }
    }
}
