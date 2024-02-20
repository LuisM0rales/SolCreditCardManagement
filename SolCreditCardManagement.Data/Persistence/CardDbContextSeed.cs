using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Infrastructure.Persistence
{
    public class CardDbContextSeed
    {
        public static async Task SeedAsync(CardDbContext context, ILogger<CardDbContext> logger)
        {
            if(!context.Customers!.Any())
            {
                context.Customers!.AddRange(GetSeededCustomers());
                await context.SaveChangesAsync();
                logger.LogInformation("Insertando datos desde seed a la base de datos {context}", typeof(CardDbContext).Name);
            }
        }

        private static IEnumerable<Customer> GetSeededCustomers()
        {
            return new List<Customer>()
            {
                new Customer { FirstName="Luis", SecondName="Jose", LastName="Morales", SecondLastName="Landaverde"},
                new Customer { FirstName="Raul", SecondName="Jose", LastName="Barra", SecondLastName="Cartago"}
            };
        }
    }
}
