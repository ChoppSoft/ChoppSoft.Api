using FluentValidation;

namespace ChoppSoft.Domain.Models.Suppliers.Services.Validators
{
    public class SupplierCreateValidator : AbstractValidator<Supplier>
    {
        public SupplierCreateValidator()
        {
            RuleFor(supplier => supplier.Name)
                .NotNull().NotEmpty()
                .WithMessage("O fornecedor precisa conter um nome para identificação.");

            RuleFor(supplier => supplier.ContactName)
                .NotNull().NotEmpty()
                .WithMessage("O fornecedor precisa conter um nome para o contato.");

            RuleFor(supplier => supplier.Email)
                .EmailAddress()
                .WithMessage("Formato de e-mail inválido para o fornecedor.");

            RuleFor(supplier => supplier.PhoneNumber)
                .Matches(@"^\d{2}9\d{8}$")
                .WithMessage("Número de telefone inválido. O formato esperado é '48999999999' por exemplo.");
        }
    }
}
