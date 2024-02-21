using FluentValidation;

namespace SolCreditCardManagement.Application.Features.Transactions.Commands.CreateTransactions
{
    public class CreateTransactionsCommandValidator : AbstractValidator<CreateTransactionsCommand>
    {
        public CreateTransactionsCommandValidator()
        {
            RuleFor(c => c.Amount)
                .NotNull().WithMessage("{Amount} no puede ser nulo");
            RuleFor(c => c.Description)
                .NotNull().WithMessage("{Description} no puede ser nulo");
            RuleFor(c => c.Description)
                .NotNull().WithMessage("{Description} no puede ser nulo");
        }
    }
}
