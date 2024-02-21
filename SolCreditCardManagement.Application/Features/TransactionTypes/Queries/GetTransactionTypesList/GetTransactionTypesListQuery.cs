using MediatR;

namespace SolCreditCardManagement.Application.Features.TransactionTypes.Queries.GetTransactionTypesList
{
    public class GetTransactionTypesListQuery : IRequest<List<TransactionTypeVm>>
    {
        public GetTransactionTypesListQuery()
        {

        }
    }
}
