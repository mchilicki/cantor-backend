using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Factories.Currencies.Base;
using Chilicki.Cantor.Domain.Services.Buying.Base;
using Chilicki.Cantor.Domain.Validators.Buying.Base;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Services.Buying
{
    public class BuyCurrencyService : IBuyCurrencyService
    {
        readonly IWalletCurrencyFactory walletCurrencyFactory;
        readonly IBuyCurrencyValidator buyCurrencyValidator;

        public BuyCurrencyService(
            IWalletCurrencyFactory walletCurrencyFactory,
            IBuyCurrencyValidator buyCurrencyValidator)
        {
            this.walletCurrencyFactory = walletCurrencyFactory;
            this.buyCurrencyValidator = buyCurrencyValidator;
        }

        public User BuyCurrency(BuyCurrencyCommand command)
        {
            buyCurrencyValidator.ValidateCanBuyCurrency(command);
            ChargeCantorCosts(command);
            ChargeUserCosts(command);
            AddOrUpdateUserCurrencyAmount(command);
            return command.User;
        }                

        private void ChargeCantorCosts(BuyCurrencyCommand command)
        {
            command.CantorCurrency.Amount -= command.Amount;
        }

        private void ChargeUserCosts(BuyCurrencyCommand command)
        {
            command.User.Money -= command.UserMoneyCosts;
        }

        private void AddOrUpdateUserCurrencyAmount(BuyCurrencyCommand command)
        {
            if (command.UserCurrency == null)
                AddNewCurrency(command);
            else
                EditCurrencyAmount(command);
        }

        private void AddNewCurrency(BuyCurrencyCommand command)
        {
            if (command.User.Currencies == null)
                command.User.Currencies = new List<WalletCurrency>();
            var userCurrency = walletCurrencyFactory.Create(command.Currency, command.User, command.Amount);
            command.User.Currencies.Add(userCurrency);
        }

        private void EditCurrencyAmount(BuyCurrencyCommand command)
        {
            command.UserCurrency.Amount += command.Amount;
        }        
    }
}
