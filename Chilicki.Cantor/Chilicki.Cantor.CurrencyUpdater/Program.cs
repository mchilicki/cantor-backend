using Chilicki.Cantor.Infrastructure.Repositories.Currencies;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Chilicki.Cantor.CurrencyUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddTransient<Application.CommandHandlers.CurrencyUpdaters.CurrencyUpdater>()
                .AddTransient<ICurrencyRepository, CurrencyRepository>()
                .BuildServiceProvider();


            //do the actual work here
            var currencyUpdater = serviceProvider.GetService<Application.CommandHandlers.CurrencyUpdaters.CurrencyUpdater>();
            //currencyUpdater.DoSomeRealWork();
        }
    }
}
