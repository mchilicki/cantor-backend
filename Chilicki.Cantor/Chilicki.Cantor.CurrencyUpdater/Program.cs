using Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters.Base;
using Chilicki.Cantor.Domain.Factories.Initializing;
using Chilicki.Cantor.Domain.Factories.Initializing.Base;
using Chilicki.Cantor.Domain.Services.Currencies;
using Chilicki.Cantor.Domain.Services.Currencies.Base;
using Chilicki.Cantor.Infrastructure.Databases;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using Chilicki.Cantor.Infrastructure.RestClients;
using Chilicki.Cantor.Infrastructure.RestClients.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Chilicki.Cantor.CurrencyUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var serviceProvider = CreateDependencyInjection();
            var currencyUpdater = serviceProvider.GetService<ICurrencyUpdater>();
            try
            {
                await currencyUpdater.InitializeAndUpdateCurrencies();
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }            
        }

        static ServiceProvider CreateDependencyInjection()
        {
            var connectionString = "data source=localhost;initial catalog=CantorDevelopment;integrated security=True;MultipleActiveResultSets=True;";
            var serviceProvider = new ServiceCollection()
               .AddTransient<ICurrencyUpdater, Application.CommandHandlers.CurrencyUpdaters.CurrencyUpdater>()
               .AddTransient<ICurrencyRepository, CurrencyRepository>()
               .AddTransient<ICantorWalletRepository, CantorWalletRepository>()
               .AddTransient<ICantorCurrencyRepository, CantorCurrencyRepository>()
               .AddTransient<ICurrencyUpdateService, CurrencyUpdateService>()
               .AddTransient<IInitializeCurrenciesFactory, InitializeCurrenciesFactory>()
               .AddTransient<ICurrencyUpdaterRestClient, CurrencyUpdaterRestClient>()
               .AddTransient<IUnitOfWork, UnitOfWork>()
               .AddDbContext<DbContext, CantorDatabaseContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    b => b.MigrationsAssembly(typeof(CantorDatabaseContext).Assembly.GetName().Name
                    ))
                )
               .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
