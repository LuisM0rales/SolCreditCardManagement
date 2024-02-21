using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.GlobalConfigurations.Commands.CreateGlobalConfigurations
{
    public class CreateGlobalConfigurationsCommandHandler : IRequestHandler<CreateGlobalConfigurationsCommand, int>
    {
        private readonly ILogger<CreateGlobalConfigurationsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGlobalConfigurationsCommandHandler(ILogger<CreateGlobalConfigurationsCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateGlobalConfigurationsCommand request, CancellationToken cancellationToken)
        {
            var globalConfEntity = _mapper.Map<GlobalConfiguration>(request);
            _unitOfWork.Repository<GlobalConfiguration>().AddEntity(globalConfEntity);
            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                _logger.LogError("No se pudo insertar el dato de configuracion global");
                throw new Exception("No se pudo insertar el dato de configuracion global");
            }

            return globalConfEntity.Id;
        }
    }
}
