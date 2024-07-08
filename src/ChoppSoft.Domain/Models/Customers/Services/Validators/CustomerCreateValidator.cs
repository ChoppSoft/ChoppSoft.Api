using ChoppSoft.Domain.Models.Orders;
using ChoppSoft.Domain.Models.Orders.Enums;
using FluentValidation;

namespace ChoppSoft.Domain.Models.Customers.Services.Validators
{
    public class CustomerCreateValidator : AbstractValidator<Customer>
    {
        private readonly Func<string, Task<bool>> _beUniqueDocumentAsync;

        public CustomerCreateValidator(Func<string, Task<bool>> beUniqueDocumentAsync)
        {
            _beUniqueDocumentAsync = beUniqueDocumentAsync;

            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.");

            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email não está em um formato válido.");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .Must(BeAValidDate).WithMessage("A data de nascimento não é válida.")
                .Must(BeAtLeast18YearsOld).WithMessage("O cliente deve ter pelo menos 18 anos.");

            RuleFor(customer => customer.Document)
                .NotEmpty().WithMessage("O documento é obrigatório.")
                .MustAsync(async (document, cancellation) => await _beUniqueDocumentAsync(document))
                .WithMessage("Já existe um cliente com este documento na base.");
        }

        private bool BeAValidDate(DateTime dateOfBirth)
        {
            return dateOfBirth > DateTime.MinValue && dateOfBirth < DateTime.Today;
        }

        private bool BeAtLeast18YearsOld(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age)) 
                age--;

            return age >= 18;
        }
    }
}
