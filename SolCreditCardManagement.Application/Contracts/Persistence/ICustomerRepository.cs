using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomerByName(string name);
    }
}
