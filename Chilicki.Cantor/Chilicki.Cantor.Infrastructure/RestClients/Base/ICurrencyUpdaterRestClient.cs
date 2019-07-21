using Chilicki.Cantor.Domain.Aggregates;
using Chilicki.Cantor.Domain.Aggregates.Currencies;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Infrastructure.RestClients.Base
{
    public interface ICurrencyUpdaterRestClient
    {
        UpdatedCurrencies GetUpdatedCurrencies();
    }
}
