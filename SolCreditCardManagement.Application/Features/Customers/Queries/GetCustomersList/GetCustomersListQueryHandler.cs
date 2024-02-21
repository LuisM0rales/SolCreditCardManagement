using AutoMapper;
using MediatR;
using SolCreditCardManagement.Application.Contracts.Persistence;

namespace SolCreditCardManagement.Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomerVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CustomerVm>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customerList = await _unitOfWork.CustomerRepository.GetCustomerByName(request._customerName);

            return _mapper.Map<List<CustomerVm>>(customerList);
        }
    }
}
