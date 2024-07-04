using ChoppSoft.Domain.Models.Orders;
using ChoppSoft.Domain.Models.Payments.Enums;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Payments
{
    public sealed class Payment : Entity
    {
        public Payment(Guid orderId, 
                       DateTime paymentDate, 
                       decimal amount, 
                       EnumPaymentMethod method)
        {
            OrderId = orderId;
            PaymentDate = paymentDate;
            Amount = amount;
            Method = method;
        }

        public Payment() { }

        public Guid OrderId { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public decimal Amount { get; private set; }
        public EnumPaymentMethod Method { get; private set; }

        public Order Order { get; private set; }
    }
}
