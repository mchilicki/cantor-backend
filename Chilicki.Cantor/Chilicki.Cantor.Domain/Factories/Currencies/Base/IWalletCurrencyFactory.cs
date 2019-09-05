using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Factories.Currencies.Base
{
    public interface IWalletCurrencyFactory
    {
        WalletCurrency Create(Currency currency, User owner, int amount);
    }
}
