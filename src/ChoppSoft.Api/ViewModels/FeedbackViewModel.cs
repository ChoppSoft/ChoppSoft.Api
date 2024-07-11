using ChoppSoft.Domain.Models.Feedbacks.Enums;

namespace ChoppSoft.Api.ViewModels
{
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public string Comments { get; set; }
        public EnumRating Rating { get; set; }

        public CustomerViewModel Customer { get; set; }
        public OrderViewModel Order { get; set; }
    }
}
