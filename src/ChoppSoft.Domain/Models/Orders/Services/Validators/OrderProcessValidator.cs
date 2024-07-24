using ChoppSoft.Domain.Models.Orders.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Orders.Services.Validators
{
    public class OrderProcessValidator : AbstractValidator<Order>
    {
        public OrderProcessValidator()
        {
            RuleFor(order => order.Status)
                .Equal(EnumOrderStatus.Pending)
                .WithMessage("O pedido só pode ser processado se estiver no status 'Pending'.");

            RuleFor(order => order.TotalAmount)
                .GreaterThan(0)
                .WithMessage("O total do pedido não pode ser 0.");

            RuleFor(order => order.AddressId)
                .NotNull()
                .WithMessage("Deve informar um e-mail para processar o pedido.");

            RuleFor(order => order.Paid)
                .Equal(false)
                .WithMessage("O pedido está marcado como pago, verifique se o pedido já não está processado.");

            RuleFor(order => order.Shipped)
                .Equal(false)
                .WithMessage("O pedido está marcado como despachado, verifique se o pedido já não está processado.");
        }
    }
}
