using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chilicki.Cantor
{
    public static class WalletCurrencyExtensions
    {
        public static WalletCurrency FindByCurrency(this IEnumerable<WalletCurrency> walletCurrencies, Guid currencyId)
        {
            if (walletCurrencies == null)
                return null;
            return walletCurrencies
                .FirstOrDefault(p => p.Currency.Id == currencyId);
        }

        public static WalletCurrency FindByCurrency(this IEnumerable<WalletCurrency> walletCurrencies, Currency currency)
        {
            if (walletCurrencies == null)
                return null;
            return walletCurrencies
                .FirstOrDefault(p => p.Currency.Id == currency.Id);
        }
    }
}
