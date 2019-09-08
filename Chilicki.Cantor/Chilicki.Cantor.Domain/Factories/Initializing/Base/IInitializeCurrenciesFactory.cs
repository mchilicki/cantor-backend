using Chilicki.Cantor.Domain.Entities;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Factories.Initializing.Base
{
    public interface IInitializeCurrenciesFactory
    {
        CantorWallet CreateDefaultCantorWallet();
        ICollection<Currency> CreateDefaultCurrencies();
        ICollection<CantorCurrency> CreateDefaultCantorCurrencies(CantorWallet defaultCantorWallet, IEnumerable<Currency> defaultCurrencies);
    }
}
