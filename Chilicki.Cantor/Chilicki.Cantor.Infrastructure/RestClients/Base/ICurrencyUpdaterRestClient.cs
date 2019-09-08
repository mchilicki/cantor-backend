using Chilicki.Cantor.Domain.Aggregates.Currencies;

namespace Chilicki.Cantor.Infrastructure.RestClients.Base
{
    public interface ICurrencyUpdaterRestClient
    {
        UpdatedCurrencies GetUpdatedCurrencies();
    }
}
