using ChoppSoft.Domain.Models.Payments.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Payments.Services.Validators
{
    public class PaymentCancelValidator : AbstractValidator<Payment>
    {
        public PaymentCancelValidator()
        {
            RuleFor(payment => payment.Status)
                .NotEqual(EnumStatusPayment.Canceled)
                .WithMessage("O pagamento já está com o status 'Cancelado'");
        }
    }
}
