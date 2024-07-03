using ChoppSoft.Domain.Models.Feedbacks.Enums;

namespace ChoppSoft.Domain.Models.Feedbacks.Services.Dtos
{
    public record FeedbackDto(Guid customerid,
                              Guid orderid,
                              string comments,
                              EnumRating rating);
    
}
