using ChoppSoft.Domain.Models.Payments.Enums;

namespace ChoppSoft.Domain.Models.Payments.Services.Dtos
{
    public record PaymentDto(Guid orderId,
                             EnumPaymentMethod method,
                             EnumTypeDiscount typediscount,
                             decimal discount,
                             decimal expenses);
}
