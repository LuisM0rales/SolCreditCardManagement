using Microsoft.EntityFrameworkCore;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;
using SolCreditCardManagement.Infrastructure.Persistence;

namespace SolCreditCardManagement.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CardDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Customer>> GetCustomerByName(string name)
        {
            return await _context.Customers!.Where(c => c.FirstName == name || c.SecondName == name).ToListAsync();
        }
    }
}
