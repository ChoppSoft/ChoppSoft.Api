using ChoppSoft.Domain.Models.Orders.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Orders.Services.Validators
{
    public class OrderUpdateItemValidator : AbstractValidator<Order>
    {
        public OrderUpdateItemValidator()
        {
            RuleFor(order => order.Status)
                .Equal(EnumOrderStatus.Pending)
                .WithMessage("Só pode ser alterado itens se o pedido estiver com status 'Pending'.");
        }
    }
}
