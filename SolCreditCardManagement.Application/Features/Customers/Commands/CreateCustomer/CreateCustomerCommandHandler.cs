using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Customer>(request);
            var newCustomer = await _customerRepository.AddAsync(customerEntity);

            _logger.LogInformation($"Customer {newCustomer.Id} fue creado exitosamente.");

            return newCustomer.Id;
        }
    }
}
