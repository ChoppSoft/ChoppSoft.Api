using FluentValidation;

namespace ChoppSoft.Domain.Models.Orders.Services.Validators
{
    public class OrderChangeDeliveryDateValidator : AbstractValidator<Order>
    {
        public OrderChangeDeliveryDateValidator()
        {
            RuleFor(order => order.Shipped)
                .Equal(true)
                .WithMessage("O pedido só pode alterar a data de entrega antes dos produtos serem enviados.");
        }
    }
}
