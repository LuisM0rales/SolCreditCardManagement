using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Application.Exceptions;
using SolCreditCardManagement.Data;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.UpdateCreditCardStatuses
{
    public class UpdateCreditCardStatusesCommandHandler : IRequestHandler<UpdateCreditCardStatusesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCreditCardStatusesCommandHandler> _logger;

        public UpdateCreditCardStatusesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCreditCardStatusesCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCreditCardStatusesCommand request, CancellationToken cancellationToken)
        {
            var ccStatusToUpdate = _unitOfWork.Repository<CreditCardStatus>().GetByIdAsync(request.Id).Result;
            if (ccStatusToUpdate == null)
            {
                _logger.LogError($"No se encontro el estatus de tarjeta con id {request.Id}");
                throw new NotFoundException(nameof(GlobalConfiguration), request.Id);
            }

            _mapper.Map(request, ccStatusToUpdate, typeof(UpdateCreditCardStatusesCommand), typeof(CreditCardStatus));

            _unitOfWork.Repository<CreditCardStatus>().UpdateEntity(ccStatusToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el estatus de tarjeta con id {request.Id}");

            return Unit.Value;
        }
    }
}
