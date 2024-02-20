using AutoMapper;
using SolCreditCardManagement.Application.Features.Customers.Commands.CreateCustomer;
using SolCreditCardManagement.Application.Features.Customers.Queries.GetCustomersList;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerVm>();
            CreateMap<CreateCustomerCommand, Customer>();
        }
    }
}
