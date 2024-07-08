using ChoppSoft.Domain.Models.Orders.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Orders.Services.Validators
{
    public class OrderConfirmValidator : AbstractValidator<Order>
    {
        public OrderConfirmValidator()
        {
            RuleFor(order => order.Status)
                .Equal(EnumOrderStatus.Processing)
                .WithMessage("O pedido só pode ser confirmado se estiver no status 'Processing'.");

            RuleFor(order => order.Shipped)
                .Equal(true)
                .WithMessage("O pedido só pode ser confirmado após os produtos forem enviados.");

            RuleFor(order => order.Delivered)
                .Equal(true)
                .WithMessage("O pedido só pode ser confirmado após os produtos serem entregues.");

            RuleFor(order => order.TotalAmount)
                .GreaterThan(0)
                .WithMessage("O pedido só pode ser confirmado com valor definido.");

            RuleFor(order => order.Paid)
                .Equal(true)
                .WithMessage("O pedido só pode ser confirmado após ser recebido.");
        }
    }
}
