using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Data;

namespace SolCreditCardManagement.Application.Features.CreditCards.Commands.CreateCreditCard
{
    public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCreditCardCommandHandler> _logger;

        public CreateCreditCardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCreditCardCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
        {
            var creditcardEntity = _mapper.Map<CreditCard>(request);
            _unitOfWork.Repository<CreditCard>().AddEntity(creditcardEntity);
            var result = await _unitOfWork.Complete();

            if(result <=0)
            {
                throw new Exception($"No se pudo insertar el dato");
            }
            _logger.LogInformation($"Credit Card {creditcardEntity.Id} fue creado exitosamente.");

            return creditcardEntity.Id;
        }
    }
}
