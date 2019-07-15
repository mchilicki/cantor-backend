using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters.Base
{
    public interface ICurrencyUpdater
    {
        Task InitializeAndUpdateCurrencies();
        Task InitializeCurrencies();
        Task UpdateCurrencies();
        Task<bool> AreCurrenciesInitialized();
    }
}
