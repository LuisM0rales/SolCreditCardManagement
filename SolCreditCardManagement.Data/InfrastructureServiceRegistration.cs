using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Infrastructure.Persistence;
using SolCreditCardManagement.Infrastructure.Repositories;

namespace SolCreditCardManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CardDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<CardDbContextSeed>();
            var scope = services.BuildServiceProvider().CreateScope();
            var dbIni = scope.ServiceProvider.GetRequiredService<CardDbContextSeed>();
            dbIni.SeedAsync().Wait();


            return services;
        }
    }
}
