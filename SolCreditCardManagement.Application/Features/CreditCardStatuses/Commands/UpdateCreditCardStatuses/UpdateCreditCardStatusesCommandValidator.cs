using FluentValidation;

namespace SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.UpdateCreditCardStatuses
{
    public class UpdateCreditCardStatusesCommandValidator : AbstractValidator<UpdateCreditCardStatusesCommand>
    {
        public UpdateCreditCardStatusesCommandValidator()
        {
            RuleFor(p => p.CreditCardStatusCode)
                .NotEmpty().WithMessage("{CreditCardStatusCode} no puede estar en blanco")
                .NotNull();
            RuleFor(p => p.CreditCardStatusName)
                .NotEmpty().WithMessage("{CreditCardStatusName} no puede estar en blanco")
                .NotNull();
        }
    }
}
