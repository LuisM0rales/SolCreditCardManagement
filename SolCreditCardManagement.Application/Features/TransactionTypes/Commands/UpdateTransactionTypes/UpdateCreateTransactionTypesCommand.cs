using MediatR;

namespace SolCreditCardManagement.Application.Features.TransactionTypes.Commands.UpdateTransactionTypes
{
    public class UpdateCreateTransactionTypesCommand : IRequest
    {
        public int Id { get; set; }
        public string? TransactionTypeCode { get; set; }
        public string? TransactionTypeDescription { get; set; }
    }
}
