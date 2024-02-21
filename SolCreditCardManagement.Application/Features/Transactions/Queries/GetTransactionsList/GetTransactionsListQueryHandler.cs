using AutoMapper;
using MediatR;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQueryHandler : IRequestHandler<GetTransactionsListQuery, List<TransactionVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTransactionsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TransactionVm>> Handle(GetTransactionsListQuery request, CancellationToken cancellationToken)
        {
            var transactionList = await _unitOfWork.Repository<Transaction>().GetAllAsync();

            return _mapper.Map<List<TransactionVm>>(transactionList);
        }
    }
}
