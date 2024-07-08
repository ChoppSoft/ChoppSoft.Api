using FluentValidation;

namespace ChoppSoft.Domain.Models.Addresses.Services.Validators
{
    public class AddressCreateValidator : AbstractValidator<Address>
    {
        public AddressCreateValidator()
        {
            RuleFor(customer => customer.CustomerId)
                .NotNull()
                .WithMessage("O código do cliente é obrigatório.");

            RuleFor(customer => customer.Street)
                .NotEmpty()
                .WithMessage("A rua é obrigatório.");

            RuleFor(customer => customer.Number)
                .NotEmpty()
                .WithMessage("O número é obrigatório.");

            RuleFor(customer => customer.District)
                .NotEmpty()
                .WithMessage("O bairro é obrigatório.");

            RuleFor(customer => customer.City)
                .NotEmpty()
                .WithMessage("A cidade é obrigatório.");

            RuleFor(customer => customer.State)
                .NotEmpty()
                .WithMessage("A sigla do estado é obrigatório.");

            RuleFor(customer => customer.PostalCode)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .Length(8).WithMessage("O CEP deve ter 8 caracteres.")
                .Matches("^[0-9]{8}$").WithMessage("O CEP deve conter apenas números.");

            RuleFor(customer => customer.Country)
                .NotEmpty()
                .WithMessage("O país é obrigatório.");
        }
    }
}
