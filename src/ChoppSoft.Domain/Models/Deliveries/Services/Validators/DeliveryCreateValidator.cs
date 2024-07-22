using ChoppSoft.Infra.Extensions;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Deliveries.Services.Validators
{
    public class DeliveryCreateValidator : AbstractValidator<Delivery>
    {
        public DeliveryCreateValidator()
        {
            RuleFor(delivery => delivery.OrderId)
                .NotNull()
                .WithMessage("É preciso informar um pedido para iniciar a entrega.");

            RuleFor(delivery => delivery.ResourceId)
                .NotNull()
                .WithMessage("É preciso informar um recurso para iniciar a entrega.");

            RuleFor(delivery => delivery.DeliveryDate)
                .NotNull().WithMessage("É preciso informar uma data de entrega.")
                .Must(BeAValidDate).WithMessage($"A data de entrega precisa ser maior ou equivalente à hoje - {DateTime.Now.ToBrazilianDateFormat()}");

            RuleFor(delivery => delivery.ScheduledDate)
                .NotNull().WithMessage("É preciso informar uma data final de entrega.")
                .Must(BeAValidDate).WithMessage($"A data de entrega final precisa ser maior ou equivalente à hoje - {DateTime.Now.ToBrazilianDateFormat()}");
        }

        private bool BeAValidDate(DateTime? deliveryDate)
        {
            return deliveryDate?.Date >= DateTime.Now.Date;
        }

        private bool BeAValidDate(DateTime deliveryDate)
        {
            return deliveryDate.Date >= DateTime.Now.Date;
        }
    }
}
