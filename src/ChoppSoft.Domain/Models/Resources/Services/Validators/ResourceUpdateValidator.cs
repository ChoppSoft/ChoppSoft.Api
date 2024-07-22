using FluentValidation;

namespace ChoppSoft.Domain.Models.Resources.Services.Validators
{
    public class ResourceUpdateValidator : AbstractValidator<Resource>
    {
        public ResourceUpdateValidator()
        {
            RuleFor(resource => resource.Description)
                .NotNull().NotEmpty()
                .WithMessage("O recurso precisa conter uma descrição.");

            RuleFor(resource => resource.Model)
                .NotNull().NotEmpty()
                .WithMessage("O recurso precisa conter um modelo.");

            RuleFor(resource => resource.LicensePlate)
                .NotNull().NotEmpty()
                .WithMessage("O recurso precisa conter uma placa.");

            RuleFor(resource => resource.Capacity)
                .NotNull().NotEmpty()
                .WithMessage("O recurso precisa conter uma capacidade de carga.");

            RuleFor(resource => resource.IsOwned)
                .NotNull()
                .WithMessage("O recurso precisa informar se é próprio ou de terceiros.");
        }
    }
}
