using AutoMapper;
using MediatR;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.Statements.Queries.GetStatementByICreditCardId
{
    public class GetStatementByICreditCardIdQueryHandler : IRequestHandler<GetStatementByICreditCardIdQuery, StatementVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStatementByICreditCardIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StatementVm> Handle(GetStatementByICreditCardIdQuery request, CancellationToken cancellationToken)
        {
            var statementData = await _unitOfWork.Repository<Statement>().GetByProcedure($"EXEC dbo.StatementDataCreditCard @CreditCardId = {request._id}");

            return _mapper.Map<StatementVm>(statementData);
        }
    }
}
