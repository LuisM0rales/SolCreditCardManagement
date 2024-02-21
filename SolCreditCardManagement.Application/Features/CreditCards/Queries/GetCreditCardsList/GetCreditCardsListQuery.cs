using MediatR;

namespace SolCreditCardManagement.Application.Features.CreditCards.Queries.GetCreditCardsList
{
    public class GetCreditCardsListQuery : IRequest<List<CreditCardVm>>
    {
        public GetCreditCardsListQuery()
        {

        }
    }
}
