using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Application.Exceptions;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.TransactionTypes.Commands.UpdateTransactionTypes
{
    public class UpdateCreateTransactionTypesCommandHandler : IRequestHandler<UpdateCreateTransactionTypesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCreateTransactionTypesCommandHandler> _logger;

        public UpdateCreateTransactionTypesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCreateTransactionTypesCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCreateTransactionTypesCommand request, CancellationToken cancellationToken)
        {
            var transactionTypeToUpdate = _unitOfWork.Repository<TransactionType>().GetByIdAsync(request.Id).Result;

            if (transactionTypeToUpdate == null)
            {
                _logger.LogError($"No se encontro el customer id {request.Id}");
                throw new NotFoundException(nameof(TransactionType), request.Id);
            }

            _mapper.Map(request, transactionTypeToUpdate, typeof(UpdateCreateTransactionTypesCommand), typeof(TransactionType));

            _unitOfWork.Repository<TransactionType>().UpdateEntity(transactionTypeToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el dato {request.Id}");

            return Unit.Value;
        }
    }
}
