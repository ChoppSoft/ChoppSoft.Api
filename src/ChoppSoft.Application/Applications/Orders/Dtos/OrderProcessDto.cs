using ChoppSoft.Domain.Models.Deliveries.Services.Dtos;
using ChoppSoft.Domain.Models.Payments.Services.Dtos;

namespace ChoppSoft.Application.Applications.Orders.Dtos
{
    public record OrderProcessDto(PaymentDto payment, DeliveryDto delivery);
}
