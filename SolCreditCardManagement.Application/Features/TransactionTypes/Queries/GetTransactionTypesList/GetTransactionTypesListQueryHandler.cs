using AutoMapper;
using MediatR;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.TransactionTypes.Queries.GetTransactionTypesList
{
    public class GetTransactionTypesListQueryHandler : IRequestHandler<GetTransactionTypesListQuery, List<TransactionTypeVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTransactionTypesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TransactionTypeVm>> Handle(GetTransactionTypesListQuery request, CancellationToken cancellationToken)
        {
            var transactionTypeList = await _unitOfWork.Repository<TransactionType>().GetAllAsync();

            return _mapper.Map<List<TransactionTypeVm>>(transactionTypeList);
        }
    }
}
