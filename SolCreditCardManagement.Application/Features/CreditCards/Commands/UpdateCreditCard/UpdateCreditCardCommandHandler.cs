using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Application.Exceptions;
using SolCreditCardManagement.Data;

namespace SolCreditCardManagement.Application.Features.CreditCards.Commands.UpdateCreditCard
{
    public class UpdateCreditCardCommandHandler : IRequestHandler<UpdateCreditCardCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCreditCardCommandHandler> _logger;

        public UpdateCreditCardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCreditCardCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCreditCardCommand request, CancellationToken cancellationToken)
        {
            var creditCardToUpdate = await _unitOfWork.Repository<CreditCard>().GetByIdAsync(request.Id);

            if (creditCardToUpdate == null)
            {
                _logger.LogError($"No se encontro el id {request.Id}");
                throw new NotFoundException(nameof(CreditCard), request.Id);
            }

            _mapper.Map(request, creditCardToUpdate, typeof(UpdateCreditCardCommand), typeof(CreditCard));

            _unitOfWork.Repository<CreditCard>().UpdateEntity(creditCardToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el customer {request.Id}");

            return Unit.Value;
        }
    }
}
