using Microsoft.Extensions.Logging;
using SolCreditCardManagement.Data;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Infrastructure.Persistence
{
    public class CardDbContextSeed
    {
        private readonly CardDbContext _context;
        private readonly ILogger<CardDbContext> _logger;

        public CardDbContextSeed(CardDbContext context, ILogger<CardDbContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.GlobalConfigurations!.Any())
            {
                _context.GlobalConfigurations!.AddRange(GetSeededGlobalConfigurations());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Insertando datos desde seed a la base de datos {context}", typeof(CardDbContext).Name);
            }

            if (!_context.Customers!.Any())
            {
                _context.Customers!.AddRange(GetSeededCustomers());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Insertando datos desde seed a la base de datos {context}", typeof(CardDbContext).Name);
            }

            if (!_context.CreditCardStatuses!.Any())
            {
                _context.CreditCardStatuses!.AddRange(GetSeededCreditCardStatuses());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Insertando datos desde seed a la base de datos {context}", typeof(CardDbContext).Name);
            }

            if (!_context.TransactionTypes!.Any())
            {
                _context.TransactionTypes!.AddRange(GetSeededTransactionTypes());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Insertando datos desde seed a la base de datos {context}", typeof(CardDbContext).Name);
            }
        }

        private static IEnumerable<GlobalConfiguration> GetSeededGlobalConfigurations()
        {
            return new List<GlobalConfiguration>()
            {
                new GlobalConfiguration { Code="MPIR", ConfigurationVal="0.1" },
            };
        }

        private static IEnumerable<Customer> GetSeededCustomers()
        {
            return new List<Customer>()
            {
                new Customer { FirstName="Luis", SecondName="Jose", LastName="Morales", SecondLastName="Landaverde"},
                new Customer { FirstName="Raul", SecondName="Jose", LastName="Barra", SecondLastName="Cartago"}
            };
        }

        private static IEnumerable<CreditCardStatus> GetSeededCreditCardStatuses()
        {
            return new List<CreditCardStatus>()
            {
                new CreditCardStatus { CreditCardStatusCode= "CC_ACTIVE", CreditCardStatusName="Tarjeta Activa" }
            };
        }

        private static IEnumerable<TransactionType> GetSeededTransactionTypes()
        {
            return new List<TransactionType>()
            {
                new TransactionType { TransactionTypeCode= "PAYM", TransactionTypeDescription="Transaccion de pago" },
                new TransactionType { TransactionTypeCode= "PURCH", TransactionTypeDescription="Transaccion de compra" }
            };
        }
    }
}
