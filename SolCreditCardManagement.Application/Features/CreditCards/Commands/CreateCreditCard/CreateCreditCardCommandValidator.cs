using FluentValidation;

namespace SolCreditCardManagement.Application.Features.CreditCards.Commands.CreateCreditCard
{
    public class CreateCreditCardCommandValidator : AbstractValidator<CreateCreditCardCommand>
    {
        public CreateCreditCardCommandValidator()
        {
            RuleFor(p => p.CardNumber)
                .NotEmpty().WithMessage("{CardNumber} no puede estar en blanco")
                .NotNull();
            RuleFor(p => p.EmbossedName)
                .NotEmpty().WithMessage("{EmbossedName} no puede estar en blanco")
                .NotNull();
            RuleFor(p => p.LimitCard)
                .NotNull().WithMessage("{LimitCard} no puede ser nulo");
            RuleFor(p => p.InterestRate)
                .NotNull().WithMessage("{InterestRate} no puede ser nulo");
        }
    }
}
