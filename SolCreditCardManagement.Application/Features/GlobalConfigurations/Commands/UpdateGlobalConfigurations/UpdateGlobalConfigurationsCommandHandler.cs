using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Application.Exceptions;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.GlobalConfigurations.Commands.UpdateGlobalConfigurations
{
    public class UpdateGlobalConfigurationsCommandHandler : IRequestHandler<UpdateGlobalConfigurationsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateGlobalConfigurationsCommandHandler> _logger;

        public UpdateGlobalConfigurationsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateGlobalConfigurationsCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateGlobalConfigurationsCommand request, CancellationToken cancellationToken)
        {
            var globalConfigToUpdate = _unitOfWork.Repository<GlobalConfiguration>().GetByIdAsync(request.Id).Result;
            if (globalConfigToUpdate == null)
            {
                _logger.LogError($"No se encontro el customer id {request.Id}");
                throw new NotFoundException(nameof(GlobalConfiguration), request.Id);
            }

            _mapper.Map(request, globalConfigToUpdate, typeof(UpdateGlobalConfigurationsCommand), typeof(GlobalConfiguration));

            _unitOfWork.Repository<GlobalConfiguration>().UpdateEntity(globalConfigToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando la configuracion global {request.Id}");

            return Unit.Value;
        }
    }
}
