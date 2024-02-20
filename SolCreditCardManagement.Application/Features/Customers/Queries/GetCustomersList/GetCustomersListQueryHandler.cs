using AutoMapper;
using MediatR;
using SolCreditCardManagement.Application.Contracts.Persistence;

namespace SolCreditCardManagement.Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomerVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerVm>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customerList = await _customerRepository.GetCustomerByName(request._customerName);

            return _mapper.Map<List<CustomerVm>>(customerList);
        }
    }
}
