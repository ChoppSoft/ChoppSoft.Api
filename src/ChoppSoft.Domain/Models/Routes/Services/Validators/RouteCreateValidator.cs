using FluentValidation;

namespace ChoppSoft.Domain.Models.Routes.Services.Validators
{
    public class RouteCreateValidator : AbstractValidator<Route>
    {
        public RouteCreateValidator()
        {
            RuleFor(route => route.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("A rota precisa conter uma descrição");

            RuleFor(route => route.ResourceId)
                .NotNull()
                .WithMessage("É necessário conter um recurso para iniciar a rota");
        }
    }
}
