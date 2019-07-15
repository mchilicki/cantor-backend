using Chilicki.Cantor.Domain.Aggregates;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Infrastructure.RestClients.Base
{
    public interface ICurrencyUpdaterRestClient
    {
        UpdatedCurrencies GetUpdatedCurrencies();
    }
}
