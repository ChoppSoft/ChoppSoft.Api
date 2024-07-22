using FluentValidation;

namespace ChoppSoft.Domain.Models.Feedbacks.Services.Validators
{
    public class FeedbackCreateValidator : AbstractValidator<Feedback>
    {
        public FeedbackCreateValidator()
        {
            RuleFor(feedback => feedback.OrderId)
                .NotNull()
                .WithMessage("É preciso informar um pedido para criar um feedback.");

            RuleFor(feedback => feedback.CustomerId)
                .NotNull()
                .WithMessage("É preciso informar um cliente para criar um feedback.");

            RuleFor(feedback => feedback.Comments)
                .NotEmpty()
                .NotNull()
                .WithMessage("O comentário não pode ser vazio.");

            RuleFor(feedback => feedback.Rating)
                .NotNull()
                .WithMessage("É preciso informar a satisfação");
        }
    }
}
