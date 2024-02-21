using FluentValidation;

namespace SolCreditCardManagement.Application.Features.CreditCards.Commands.UpdateCreditCard
{
    public class UpdateCreditCardCommandValidator : AbstractValidator<UpdateCreditCardCommand>
    {
        public UpdateCreditCardCommandValidator()
        {
            RuleFor(p => p.InterestRate)
                .NotEmpty().WithMessage("{InterestRate} no puede ser nulo")
                .LessThan(0).WithMessage("{InterestRate} no puede ser menor a 0");
        }
    }
}
