using FluentValidation;

namespace ChoppSoft.Domain.Models.Warehouses.Services.Validators
{
    public class WarehouseCreateValidator : AbstractValidator<Warehouse>
    {
        public WarehouseCreateValidator()
        {
            RuleFor(warehouse => warehouse.Description)
                .NotNull().NotEmpty()
                .WithMessage("O Almoxarifado precisa de uma descrição.");

            RuleFor(warehouse => warehouse.Location)
                .NotNull().NotEmpty()
                .WithMessage("O Almoxarifado precisa de uma localização.");
        }
    }
}
