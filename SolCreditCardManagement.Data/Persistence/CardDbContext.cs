using Microsoft.EntityFrameworkCore;
using SolCreditCardManagement.Data;
using SolCreditCardManagement.Domain;
using SolCreditCardManagement.Domain.Common;

namespace SolCreditCardManagement.Infrastructure.Persistence
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress; Initial Catalog=CARDS_DB; Integrated Security=True")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<CreditCard>? CreditCards { get; set; }
        public DbSet<CreditCardStatus>? CreditCardStatuses { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<GlobalConfiguration>? GlobalConfigurations { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
        public DbSet<TransactionType>? TransactionTypes { get; set; }
        public DbSet<Statement>? Statements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statement>(Entity =>
            {
                Entity.ToView("Statements");
                Entity.HasNoKey();
            });
        }
    }
}
