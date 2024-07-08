using ChoppSoft.Domain.Models.Orders.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Orders.Services.Validators
{
    public class OrderCancelValidator : AbstractValidator<Order>
    {
        public OrderCancelValidator() 
        {
            RuleFor(order => order.Status)
                .Must(status => status == EnumOrderStatus.Processing || status == EnumOrderStatus.Pending)
                .WithMessage("O pedido só pode ser cancelado se estiver no status 'Pending' ou 'Processing'.");
        }
    }
}
