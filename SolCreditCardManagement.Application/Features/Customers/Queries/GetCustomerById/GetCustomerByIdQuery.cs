using MediatR;

namespace SolCreditCardManagement.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerByIdVm>
    {
        public int _id { get; set; }

        public GetCustomerByIdQuery(int id = 0)
        {
            _id = id;
        }
    }
}
