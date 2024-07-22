using FluentValidation;

namespace ChoppSoft.Domain.Models.Inventories.Services.Validators
{
    public class InventoryCreateValidator : AbstractValidator<Inventory>
    {
        public InventoryCreateValidator()
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
