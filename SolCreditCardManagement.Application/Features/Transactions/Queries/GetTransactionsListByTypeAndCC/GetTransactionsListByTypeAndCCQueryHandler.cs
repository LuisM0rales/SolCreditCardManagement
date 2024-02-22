using AutoMapper;
using MediatR;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsList;
using SolCreditCardManagement.Domain;
using System.Linq.Expressions;

namespace SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsListByTypeAndCC
{
    public class GetTransactionsListByTypeAndCCQueryHandler : IRequestHandler<GetTransactionsListByTypeAndCCQuery, List<TransactionVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTransactionsListByTypeAndCCQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TransactionVm>> Handle(GetTransactionsListByTypeAndCCQuery request, CancellationToken cancellationToken)
        {
            var transactionList = await _unitOfWork.Repository<Transaction>().GetAllAsync();

            return _mapper.Map<List<TransactionVm>>(transactionList.Where(x => x.TransactionTypeId == request._transactionTypeId && x.CreditCardId== request._creditCadId));
        }
    }
}
