using MediatR;

namespace SolCreditCardManagement.Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<CustomerVm>>
    {
        public string _customerName { get; set; } = string.Empty;

        public GetCustomersListQuery(string customerName)
        {
            _customerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
        }
    }
}
