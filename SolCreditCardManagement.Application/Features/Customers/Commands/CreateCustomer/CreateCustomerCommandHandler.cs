using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCustomerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Customer>(request);
            _unitOfWork.CustomerRepository.AddEntity(customerEntity);
            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                throw new Exception($"No se pudo insertar el dato de customer");
            }
            _logger.LogInformation($"Customer {customerEntity.Id} fue creado exitosamente.");

            return customerEntity.Id;
        }
    }
}
