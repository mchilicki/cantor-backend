using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chilicki.Cantor
{
    public static class CantorCurrencyExtensions
    {
        public static CantorCurrency FindByCurrency(this IEnumerable<CantorCurrency> cantorCurrencies, Guid currencyId)
        {
            if (cantorCurrencies == null)
                return null;
            return cantorCurrencies
                .FirstOrDefault(p => p.Currency.Id == currencyId);
        }

        public static CantorCurrency FindByCurrency(this IEnumerable<CantorCurrency> cantorCurrencies, Currency currency)
        {
            if (cantorCurrencies == null)
                return null;
            return cantorCurrencies
                .FirstOrDefault(p => p.Currency.Id == currency.Id);
        }
    }
}
