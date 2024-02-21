using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Application.Exceptions;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            if (customerToDelete == null)
            {
                _logger.LogError($"{request.Id} no existe en el sistema");
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            _unitOfWork.CustomerRepository.DeleteEntity(customerToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.Id} customer fue eliminado con exito");

            return Unit.Value;
        }
    }
}
