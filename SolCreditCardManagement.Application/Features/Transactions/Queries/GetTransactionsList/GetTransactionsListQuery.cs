using MediatR;

namespace SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQuery : IRequest<List<TransactionVm>>
    {
        public GetTransactionsListQuery()
        {

        }
    }
}
