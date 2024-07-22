using FluentValidation;

namespace ChoppSoft.Domain.Models.Inventories.Services.Validators
{
    public class InventoryUpdateValidator : AbstractValidator<Inventory>
    {
        public InventoryUpdateValidator()
        {
            RuleFor(inventory => inventory.ProductId)
                .NotNull()
                .WithMessage("É preciso informar um produto.");

            RuleFor(inventory => inventory.WarehouseId)
                .NotNull()
                .WithMessage("É preciso informar um almoxarifado.");

            RuleFor(inventory => inventory.Quantity)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithMessage("É preciso informar uma quantidade.");
        }
    }
}
