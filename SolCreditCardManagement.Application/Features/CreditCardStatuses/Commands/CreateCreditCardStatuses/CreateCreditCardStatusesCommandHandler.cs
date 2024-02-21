using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Data;

namespace SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.CreateCreditCardStatuses
{
    public class CreateCreditCardStatusesCommandHandler : IRequestHandler<CreateCreditCardStatusesCommand, int>
    {
        private readonly ILogger<CreateCreditCardStatusesCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCreditCardStatusesCommandHandler(ILogger<CreateCreditCardStatusesCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCreditCardStatusesCommand request, CancellationToken cancellationToken)
        {
            var ccStatusesEntity = _mapper.Map<CreditCardStatus>(request);
            _unitOfWork.Repository<CreditCardStatus>().AddEntity(ccStatusesEntity);
            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                _logger.LogError("No se pudo insertar el dato de configuracion global");
                throw new Exception("No se pudo insertar el dato de configuracion global");
            }

            return ccStatusesEntity.Id;
        }
    }
}
