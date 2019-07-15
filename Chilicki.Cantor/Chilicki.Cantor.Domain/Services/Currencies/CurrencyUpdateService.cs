﻿using Chilicki.Cantor.Domain.Aggregates;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Exceptions.Currencies;
using Chilicki.Cantor.Domain.Services.Currencies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chilicki.Cantor.Domain.Services.Currencies
{
    public class CurrencyUpdateService : ICurrencyUpdateService
    {
        public UpdatedCurrencies UpdateCurrencies(
            CantorWallet cantorWallet, 
            IEnumerable<Currency> currencies, 
            UpdatedCurrencies updatedCurrencies)
        {
            ValidateCantorWaller(cantorWallet);
            cantorWallet.PublicationDate = updatedCurrencies.PublicationDate;
            foreach (var currency in currencies)
            {
                var updatedCurrency = FindCurrency(updatedCurrencies, currency.Name);
                UpdateCurrency(currency, updatedCurrency);
                updatedCurrencies.Items.Remove(updatedCurrency);
            }
            return updatedCurrencies;
        }

        private Currency FindCurrency(UpdatedCurrencies updatedCurrencies, string currencyName)
        {
            return updatedCurrencies.Items
                .FirstOrDefault(p => p.Name == currencyName);
        }

        private Currency UpdateCurrency(Currency currency, Currency updatedCurrency)
        {
            if (updatedCurrency != null)
            {
                currency.PurchasePrice = updatedCurrency.PurchasePrice;
                currency.SellPrice = updatedCurrency.SellPrice;
                currency.Unit = updatedCurrency.Unit;
                currency.AveragePrice = updatedCurrency.AveragePrice;
            }
            return currency;
        }

        private bool ValidateCantorWaller(CantorWallet cantorWallet)
        {
            if (cantorWallet == null)
                throw new CannotUpdateCurrenciesException();
            return true;
        }
    }
}
