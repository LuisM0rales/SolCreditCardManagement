using FluentValidation;

namespace SolCreditCardManagement.Application.Features.TransactionTypes.Commands.CreateTransactionTypes
{
    public class CreateTransactionTypesCommandValidator : AbstractValidator<CreateTransactionTypesCommand>
    {
        public CreateTransactionTypesCommandValidator()
        {
            RuleFor(c => c.TransactionTypeCode)
                .NotNull().WithMessage("{TransactionTypeCode} no puede ser nulo");

            RuleFor(c => c.TransactionTypeDescription)
                .NotNull().WithMessage("{TransactionTypeDescription} no puede ser nulo");
        }
    }
}
