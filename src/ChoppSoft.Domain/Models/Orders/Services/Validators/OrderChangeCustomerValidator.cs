using ChoppSoft.Domain.Models.Orders.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Orders.Services.Validators
{
    public class OrderChangeCustomerValidator : AbstractValidator<Order>
    {
        public OrderChangeCustomerValidator()
        {
            RuleFor(order => order.Status)
                .Equal(EnumOrderStatus.Pending)
                .WithMessage("O pedido só pode ter o cliente alterado se estiver no status 'Pending'.");
        }
    }
}
