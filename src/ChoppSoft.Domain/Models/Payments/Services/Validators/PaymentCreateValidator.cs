using ChoppSoft.Domain.Models.Payments.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Payments.Services.Validators
{
    public class PaymentCreateValidator : AbstractValidator<Payment>
    {
        public PaymentCreateValidator()
        {
            RuleFor(payment => payment.OrderId)
                .NotNull()
                .WithMessage("É preciso informar um pedido no pagamento.");

            RuleFor(payment => payment.Method)
                .NotNull()
                .WithMessage("É preciso informar um método no pagamento.");

            RuleFor(payment => payment.Status)
                .NotEqual(EnumStatusPayment.Canceled)
                .WithMessage("O pagamento não poder ser criado como 'Cancelado'.");
        }
    }
}
