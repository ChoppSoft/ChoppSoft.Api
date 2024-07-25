using FluentValidation;

namespace ChoppSoft.Domain.Models.Products.Services.Validators
{
    public class ProductUpdateValidator : AbstractValidator<Product>
    {
        public ProductUpdateValidator()
        {
            RuleFor(product => product.Identifier)
                .NotNull()
                .NotEmpty()
                .WithMessage("O produto precisa conter uma identificação.");

            RuleFor(product => product.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("O produto precisa conter uma descrição.");

            RuleFor(product => product.Brand)
                .NotNull()
                .NotEmpty()
                .WithMessage("O produto precisa conter uma marca.");

            RuleFor(product => product.Capacity)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("O produto precisa conter uma capacidade maior que zero.");

            RuleFor(product => product.Capacity)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("O produto precisa conter um preço de venda maior que zero.");
        }
    }
}
