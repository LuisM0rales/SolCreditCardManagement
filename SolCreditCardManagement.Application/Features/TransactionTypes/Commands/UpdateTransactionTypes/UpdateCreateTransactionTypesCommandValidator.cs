using FluentValidation;

namespace SolCreditCardManagement.Application.Features.TransactionTypes.Commands.UpdateTransactionTypes
{
    public class UpdateCreateTransactionTypesCommandValidator : AbstractValidator<UpdateCreateTransactionTypesCommand>
    {
        public UpdateCreateTransactionTypesCommandValidator()
        {
            RuleFor(c => c.TransactionTypeCode)
                .NotNull().WithMessage("{TransactionTypeCode} no puede ser nulo");

            RuleFor(c => c.TransactionTypeDescription)
                .NotNull().WithMessage("{TransactionTypeDescription} no puede ser nulo");
        }
    }
}
