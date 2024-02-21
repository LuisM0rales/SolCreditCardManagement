using AutoMapper;
using MediatR;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Data;

namespace SolCreditCardManagement.Application.Features.CreditCards.Queries.GetCreditCardsList
{
    public class GetCreditCardsListQueryHandler : IRequestHandler<GetCreditCardsListQuery, List<CreditCardVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCreditCardsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CreditCardVm>> Handle(GetCreditCardsListQuery request, CancellationToken cancellationToken)
        {
            var creditCardList = await _unitOfWork.Repository<CreditCard>().GetAllAsync();

            return _mapper.Map<List<CreditCardVm>>(creditCardList.ToList());
        }
    }
}
