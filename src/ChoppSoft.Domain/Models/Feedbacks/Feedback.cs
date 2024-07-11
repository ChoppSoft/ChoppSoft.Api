using ChoppSoft.Domain.Models.Customers;
using ChoppSoft.Domain.Models.Feedbacks.Enums;
using ChoppSoft.Domain.Models.Feedbacks.Services.Dtos;
using ChoppSoft.Domain.Models.Orders;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Feedbacks
{
    public sealed class Feedback : Entity
    {
        public Feedback(Guid customerId, 
                        Guid orderId, 
                        string comments, 
                        EnumRating rating)
        {
            CustomerId = customerId;
            OrderId = orderId;
            Comments = comments;
            Rating = rating;
        }

        public Feedback() { }

        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }
        public string Comments { get; private set; }
        public EnumRating Rating { get; private set; }

        public Customer Customer { get; private set; }
        public Order Order { get; private set; }

        internal void Update(FeedbackDto dto)
        {
            CustomerId = dto.customerid;
            OrderId = dto.orderid;
            Comments = dto.comments;
            Rating = dto.rating;
        }
    }
}
