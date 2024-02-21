using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Application.Exceptions;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

            if (customerToUpdate == null)
            {
                _logger.LogError($"No se encontro el customer id {request.Id}");
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(Customer));

            _unitOfWork.CustomerRepository.UpdateEntity(customerToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el customer {request.Id}");

            return Unit.Value;
        }
    }
}
