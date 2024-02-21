using MediatR;

namespace SolCreditCardManagement.Application.Features.Transactions.Commands.CreateTransactions
{
    public class CreateTransactionsCommand : IRequest<int>
    {
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public int TransactionTypeId { get; set; }
        public int CreditCardId { get; set; }
    }
}
