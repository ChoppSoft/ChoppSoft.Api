using ChoppSoft.Domain.Models.Orders.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Orders.Services.Validators
{
    public class OrderUndoConfirmValidator : AbstractValidator<Order>
    {
        public OrderUndoConfirmValidator()
        {
            RuleFor(order => order.Status)
                .Equal(EnumOrderStatus.Confirmed)
                .WithMessage("O pedido só pode ser desfeito se estiver no status 'Confirmed'.");
        }
    }
}
