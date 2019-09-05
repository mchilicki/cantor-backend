using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Factories.Currencies.Base;
using Chilicki.Cantor.Domain.Services.Buying.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chilicki.Cantor.Domain.Services.Buying
{
    public class BuyCurrencyService : IBuyCurrencyService
    {
        readonly IWalletCurrencyFactory walletCurrencyFactory;
        
        public BuyCurrencyService(
            IWalletCurrencyFactory walletCurrencyFactory)
        {
            this.walletCurrencyFactory = walletCurrencyFactory;
        }

        public User BuyCurrency(BuyCurrencyCommand command)
        {
            ValidateCanBuyCurrency(command);
            var cantorCurrency = command.CantorWallet.CantorCurrencies
                .FirstOrDefault(p => p.Currency.Id == command.Currency.Id);
            var userCostsInPln = CountUserCosts(command);
            cantorCurrency.Amount -= command.Amount;
            command.User.Money -= userCostsInPln;
            var boughtCurrency = command.User.BoughtCurrencies
                .FirstOrDefault(p => p.Currency.Id == command.Currency.Id);
            if (boughtCurrency == null)
                AddNewCurrency(command);
            else
                EditCurrencyAmount(boughtCurrency, command.Amount);
            return command.User;
        }        

        private void AddNewCurrency(BuyCurrencyCommand command)
        {
            if (command.User.BoughtCurrencies == null)
                command.User.BoughtCurrencies = new List<WalletCurrency>();
            var walletCurrency = walletCurrencyFactory.Create(command.Currency, command.User, command.Amount);
            command.User.BoughtCurrencies.Add(walletCurrency);
        }

        private void EditCurrencyAmount(WalletCurrency boughtCurrency, int amount)
        {
            boughtCurrency.Amount += amount;
        }

        private decimal CountUserCosts(BuyCurrencyCommand command)
        {
            var costsInPln = command.Amount * command.Currency.PurchasePrice;
            return costsInPln;
        }

        private bool ValidateCanBuyCurrency(BuyCurrencyCommand command)
        {
            //if (!HasCantorCurrencyAmount(command))
            //    return false;
            return true;
        }

        private bool HasCantorCurrencyAmount(BuyCurrencyCommand command)
        {
            var cantorCurrency = command.CantorWallet.CantorCurrencies
                .FirstOrDefault(p => p.Currency.Id == command.Currency.Id);
            return cantorCurrency.Amount >= command.Amount;
        }
    }
}
