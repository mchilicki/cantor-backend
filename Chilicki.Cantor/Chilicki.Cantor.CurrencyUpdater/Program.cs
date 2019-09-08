using Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters.Base;
using Chilicki.Cantor.CurrencyUpdater.Configurations.DependencyInjection;
using Chilicki.Cantor.CurrencyUpdater.Configurations.HostConfigurations;
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
