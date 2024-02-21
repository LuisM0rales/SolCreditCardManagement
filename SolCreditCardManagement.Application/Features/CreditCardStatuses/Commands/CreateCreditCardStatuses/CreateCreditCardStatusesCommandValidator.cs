using FluentValidation;

namespace SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.CreateCreditCardStatuses
{
    public class CreateCreditCardStatusesCommandValidator : AbstractValidator<CreateCreditCardStatusesCommand>
    {
        public CreateCreditCardStatusesCommandValidator()
        {
            RuleFor(c => c.CreditCardStatusCode)
                .NotNull().WithMessage("{CreditCardStatusCode} no puede ser nulo");

            RuleFor(c => c.CreditCardStatusName)
                .NotNull().WithMessage("{CreditCardStatusName} no puede ser nulo");
        }

    }
}
