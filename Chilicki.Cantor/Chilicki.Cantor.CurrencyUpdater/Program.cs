using Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters.Base;
using Chilicki.Cantor.CurrencyUpdater.Configurations.DependencyInjection;
using Chilicki.Cantor.CurrencyUpdater.Configurations.HostConfigurations;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            var configuration = new ApplicationConfiguration().Configure();
            var serviceProvider = new CurrencyUpdaterDIConfiguration().CreateServiceProvider(configuration);
            var currencyUpdater = serviceProvider.GetService<ICurrencyUpdater>();
            int waitingTimeInMiliseconds = 1000;
            await UpdateInLoop(currencyUpdater, waitingTimeInMiliseconds);
        }

        static async Task UpdateInLoop(ICurrencyUpdater currencyUpdater, int waitingTimeInMiliseconds)
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    bool wereCurrenciesUpdated = false;
                    try
                    {
                        Console.WriteLine("Checking for updated currencies");
                        wereCurrenciesUpdated = await currencyUpdater.InitializeAndUpdateCurrencies();
                    }
                    catch (Exception exception)
                    {
                        Console.Write(exception.Message);
                    }
                    LogUpdatingResult(wereCurrenciesUpdated);
                    await Task.Delay(waitingTimeInMiliseconds);
                }
            });                       
        }

        static void LogUpdatingResult(bool wereCurrenciesUpdated)
        {
            if (wereCurrenciesUpdated)
                Console.WriteLine("Currencies updated");
            else
                Console.WriteLine("Currencies were not updated");
        }
    }
}
