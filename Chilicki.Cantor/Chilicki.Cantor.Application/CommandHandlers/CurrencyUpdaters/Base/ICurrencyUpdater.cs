using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters.Base
{
    public interface ICurrencyUpdater
    {
        Task<bool> InitializeAndUpdateCurrencies();
        Task InitializeCurrencies();
        Task<bool> UpdateCurrencies();
        Task<bool> AreCurrenciesNotInitialized();
    }
}
