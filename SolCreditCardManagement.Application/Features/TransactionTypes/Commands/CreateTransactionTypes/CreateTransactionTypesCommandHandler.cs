using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.TransactionTypes.Commands.CreateTransactionTypes
{
    public class CreateTransactionTypesCommandHandler : IRequestHandler<CreateTransactionTypesCommand, int>
    {
        private readonly ILogger<CreateTransactionTypesCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTransactionTypesCommandHandler(ILogger<CreateTransactionTypesCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTransactionTypesCommand request, CancellationToken cancellationToken)
        {
            var transactionTypeEntity = _mapper.Map<TransactionType>(request);
            _unitOfWork.Repository<TransactionType>().AddEntity(transactionTypeEntity);
            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                _logger.LogError("No se pudo insertar el dato tipo de transaccion");
                throw new Exception("No se pudo insertar el dato tipo de transaccion");
            }

            return transactionTypeEntity.Id;
        }
    }
}
