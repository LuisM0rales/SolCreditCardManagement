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

            if (!_context.CreditCards!.Any())
            {
                _context.CreditCards!.AddRange(GetSeededCreditCards());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Insertando datos desde seed a la base de datos {context}", typeof(CardDbContext).Name);
            }

            if (!_context.Transactions!.Any())
            {
                _context.Transactions!.AddRange(GetseededTransaction());
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

        private IEnumerable<CreditCard> GetSeededCreditCards()
        {
            return new List<CreditCard>()
            {
                new CreditCard { 
                    AccountNumber = GenerateCreditCardNumber(), CardNumber = GenerateCreditCardNumber(), 
                    CreditCardStatusId=1, CustomerId= 1, EmbossedName = "Luis Morales", InterestRate=0.35,
                    LimitCard = 500.00
                },
                new CreditCard {
                    AccountNumber = GenerateCreditCardNumber(), CardNumber = GenerateCreditCardNumber(),
                    CreditCardStatusId=1, CustomerId= 2, EmbossedName = "Raul Barra", InterestRate=0.40,
                    LimitCard = 1000.00
                }
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

        private static IEnumerable<Transaction> GetseededTransaction()
        {
            return new List<Transaction>()
            {
                new Transaction { TransactionTypeId= 1, Amount=30, Description="Pago llenado", CreditCardId = 1},
                new Transaction { TransactionTypeId= 2, Amount=100, Description ="Sony Playstation", CreditCardId =1},
                new Transaction { TransactionTypeId= 2, Amount=60.99, Description ="Disney Plus", CreditCardId =1},
                new Transaction { TransactionTypeId= 2, Amount=35.25, Description ="HBO MAX", CreditCardId =1},
                new Transaction { TransactionTypeId= 1, Amount=60.39, Description ="Pago Test", CreditCardId =1},
                new Transaction { TransactionTypeId= 1, Amount=30, Description="Pago llenado", CreditCardId = 2},
                new Transaction { TransactionTypeId= 2, Amount=100, Description ="Sony Playstation", CreditCardId =2},
                new Transaction { TransactionTypeId= 2, Amount=60.99, Description ="Disney Plus", CreditCardId =2},
                new Transaction { TransactionTypeId= 2, Amount=35.25, Description ="HBO MAX", CreditCardId =2},
                new Transaction { TransactionTypeId= 1, Amount=60.39, Description ="Pago Test", CreditCardId =2}
            };
        }


        private Random random = new Random();

        private string GenerateCreditCardNumber()
        {
            // El primer dígito debe ser 4 para Visa, 5 para Mastercard, 3 para American Express, etc.
            int[] firstDigits = { 4, 5, 3 }; // Ejemplo: Visa, Mastercard, American Express
            int firstIndex = random.Next(0, firstDigits.Length);
            int firstDigit = firstDigits[firstIndex];

            // Genera los siguientes dígitos como números aleatorios
            string cardNumber = firstDigit.ToString();
            for (int i = 0; i < 15; i++)
            {
                cardNumber += random.Next(0, 10); // Genera un dígito aleatorio entre 0 y 9
            }

            // Aplica el algoritmo de Luhn para validar el número
            cardNumber += GenerateLuhnDigit(cardNumber);

            return cardNumber;
        }

        private int GenerateLuhnDigit(string cardNumber)
        {
            int sum = 0;
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cardNumber[i].ToString());
                if ((cardNumber.Length - i) % 2 == 0)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }
                sum += digit;
            }

            int checksum = (sum * 9) % 10;
            return checksum;
        }
    }
}
