using Chilicki.Cantor.Domain.Aggregates;
using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Services.Currencies.Base
{
    public interface ICurrencyUpdateService
    {
        UpdatedCurrencies UpdateCurrencies(
            CantorWallet cantorWallet,
            IEnumerable<Currency> currencies,
            UpdatedCurrencies updatedCurrencies);
    }
}
