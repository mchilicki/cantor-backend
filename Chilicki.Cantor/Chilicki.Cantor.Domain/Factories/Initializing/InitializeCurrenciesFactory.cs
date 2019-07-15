using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Factories.Initializing.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chilicki.Cantor.Domain.Factories.Initializing
{
    public class InitializeCurrenciesFactory : IInitializeCurrenciesFactory
    {
        public CantorWallet CreateDefaultCantorWallet()
        {
            return new CantorWallet() { PublicationDate = DateTime.MinValue.AddDays(1) };
        }

        public ICollection<Currency> CreateDefaultCurrencies()
        {
            return new List<Currency>
            {
                new Currency() { Name = "US Dollar", Code = "USD", Unit = 1, PurchasePrice = 3.7247M, SellPrice = 3.7409M, AveragePrice = 3.7328M },
                new Currency() { Name = "Euro", Code = "EUR", Unit = 1, PurchasePrice = 4.2584M, SellPrice = 4.2671M, AveragePrice = 4.2627M },
                new Currency() { Name = "Swiss Franc", Code = "CHF", Unit = 1, PurchasePrice = 3.8558M, SellPrice = 3.8646M, AveragePrice = 3.8602M },
                new Currency() { Name = "Russian ruble", Code = "RUB", Unit = 100, PurchasePrice = 7.2584M, SellPrice = 7.2865M, AveragePrice = 7.2725M },
                new Currency() { Name = "Czech koruna", Code = "CZK", Unit = 100, PurchasePrice = 14.9657M, SellPrice = 15.0562M, AveragePrice = 15.0110M },
                new Currency() { Name = "Pound sterling", Code = "GBP", Unit = 1, PurchasePrice = 5.6378M, SellPrice = 5.6517M, AveragePrice = 5.6448M }
            };
        }

        public ICollection<CantorCurrency> CreateDefaultCantorCurrencies(CantorWallet defaultCantorWallet, IEnumerable<Currency> defaultCurrencies)
        {
            return new List<CantorCurrency>
            {
                new CantorCurrency() { CantorWallet = defaultCantorWallet, Currency = defaultCurrencies.ElementAt(0), Amount = 10000 },
                new CantorCurrency() { CantorWallet = defaultCantorWallet, Currency = defaultCurrencies.ElementAt(1), Amount = 10000 },
                new CantorCurrency() { CantorWallet = defaultCantorWallet, Currency = defaultCurrencies.ElementAt(2), Amount = 10000 },
                new CantorCurrency() { CantorWallet = defaultCantorWallet, Currency = defaultCurrencies.ElementAt(3), Amount = 1000000 },
                new CantorCurrency() { CantorWallet = defaultCantorWallet, Currency = defaultCurrencies.ElementAt(4), Amount = 1000000 },
                new CantorCurrency() { CantorWallet = defaultCantorWallet, Currency = defaultCurrencies.ElementAt(5), Amount = 10000 },
            };
        }
    }
}
