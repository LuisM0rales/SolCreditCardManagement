using MediatR;
using SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsList;

namespace SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsListByTypeAndCC
{
    public class GetTransactionsListByTypeAndCCQuery : IRequest<List<TransactionVm>>
    {
        public int _transactionTypeId {  get; set; }
        public int _creditCadId { get; set; }

        public GetTransactionsListByTypeAndCCQuery(int transactionTypeId, int creditCadId)
        {
            _transactionTypeId = transactionTypeId;
            _creditCadId = creditCadId;
        }
    }
}
