using ChoppSoft.Domain.Models.Orders.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Orders.Services.Validators
{
    public class OrderCreateValidator : AbstractValidator<Order>
    {
        public OrderCreateValidator() 
        {
            RuleFor(order => order.CustomerId)
                .NotNull()
                .WithMessage("Só é possível criar um pedido após informar um cliente.");
        }
    }
}
