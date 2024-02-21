using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.Transactions.Commands.CreateTransactions
{
    public class CreateTransactionsCommandHandler : IRequestHandler<CreateTransactionsCommand, int>
    {
        private readonly ILogger<CreateTransactionsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTransactionsCommandHandler(ILogger<CreateTransactionsCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTransactionsCommand request, CancellationToken cancellationToken)
        {
            var transactionEntity = _mapper.Map<Transaction>(request);
            _unitOfWork.Repository<Transaction>().AddEntity(transactionEntity);
            var result = await _unitOfWork.Complete();

            if(result == 0)
            {
                _logger.LogError("No se pudo insertar el dato");
                throw new Exception("No se pudo insertar el dato");
            }

            return transactionEntity.Id;
        }
    }
}
