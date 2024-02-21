using MediatR;

namespace SolCreditCardManagement.Application.Features.CreditCardStatuses.Queries.GetCreditCardStatusesList
{
    public class GetCreditCardStatusesListQuery : IRequest<List<CreditCardStatusVm>>
    {
        public GetCreditCardStatusesListQuery()
        {

        }
    }
}
