using ChoppSoft.Domain.Models.Orders;
using ChoppSoft.Domain.Models.Payments.Enums;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Payments
{
    public sealed class Payment : Entity
    {
        public Payment(Guid orderId,
                       EnumPaymentMethod method,
                       EnumTypeDiscount typediscount,
                       decimal discount,
                       decimal expenses)
        {
            OrderId = orderId;
            Method = method;
            TypeDiscount = typediscount;
            Discount = discount;
            Status = EnumStatusPayment.Paid;
            PaymentDate = DateTime.Now;
            Expenses = expenses;
        }

        public Payment() { }

        public Guid OrderId { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public decimal Amount { get; private set; }
        public EnumPaymentMethod Method { get; private set; }
        public EnumTypeDiscount TypeDiscount { get; private set; }
        public decimal Discount { get; private set; }
        public EnumStatusPayment Status { get; private set; }
        public decimal Expenses { get; private set; }

        public Order Order { get; private set; }

        public void SetAmont(decimal amount)
        {
            Amount = amount + Expenses - Discount;
        }

        internal void MakeAsCanceled()
        {
            Status = EnumStatusPayment.Canceled;
        }
    }
}
