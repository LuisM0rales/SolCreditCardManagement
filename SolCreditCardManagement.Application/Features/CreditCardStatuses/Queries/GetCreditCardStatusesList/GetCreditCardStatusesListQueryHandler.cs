using AutoMapper;
using MediatR;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Data;

namespace SolCreditCardManagement.Application.Features.CreditCardStatuses.Queries.GetCreditCardStatusesList
{
    public class GetCreditCardStatusesListQueryHandler : IRequestHandler<GetCreditCardStatusesListQuery, List<CreditCardStatusVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCreditCardStatusesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CreditCardStatusVm>> Handle(GetCreditCardStatusesListQuery request, CancellationToken cancellationToken)
        {
            var ccStatusesList = await _unitOfWork.Repository<CreditCardStatus>().GetAllAsync();

            return _mapper.Map<List<CreditCardStatusVm>>(ccStatusesList);
        }
    }
}
