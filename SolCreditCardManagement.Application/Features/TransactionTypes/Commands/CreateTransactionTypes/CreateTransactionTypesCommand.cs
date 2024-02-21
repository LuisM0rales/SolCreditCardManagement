using MediatR;

namespace SolCreditCardManagement.Application.Features.TransactionTypes.Commands.CreateTransactionTypes
{
    public class CreateTransactionTypesCommand : IRequest<int>
    {
        public string? TransactionTypeCode { get; set; }
        public string? TransactionTypeDescription { get; set; }
    }
}
