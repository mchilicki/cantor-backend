using Chilicki.Cantor.Domain.Commands.Selling;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Services.Selling.Base;
using Chilicki.Cantor.Domain.Validators.Selling.Base;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Services.Selling
{
    public class SellCurrencyService : ISellCurrencyService
    {
        readonly ISellCurrencyValidator sellCurrencyValidator;

        public SellCurrencyService(
            ISellCurrencyValidator sellCurrencyValidator)
        {
            this.sellCurrencyValidator = sellCurrencyValidator;
        }

        public User SellCurrency(SellCurrencyCommand command)
        {
            sellCurrencyValidator.ValidateCanSellCurrency(command);
            ChargeCantorEarns(command);
            ChargeUserEarns(command);
            UpdateOrDeleteUserCurrencyAmount(command);
            return command.User;
        }

        private void ChargeCantorEarns(SellCurrencyCommand command)
        {
            command.CantorCurrency.Amount += command.Amount;
        }

        private void ChargeUserEarns(SellCurrencyCommand command)
        {
            command.User.Money += command.UserMoneyEarns;
        }

        private void UpdateOrDeleteUserCurrencyAmount(SellCurrencyCommand command)
        {
            EditCurrencyAmount(command);
            RemoveCurrencyIfShould(command);
        }        

        private void EditCurrencyAmount(SellCurrencyCommand command)
        {
            command.UserCurrency.Amount -= command.Amount;
        }

        private void RemoveCurrencyIfShould(SellCurrencyCommand command)
        {
            if (ShouldRemoveCurrency(command))
            {
                command.User.Currencies.Remove(command.UserCurrency);
            }
        }

        private bool ShouldRemoveCurrency(SellCurrencyCommand command)
        {
            return command.UserCurrency.Amount == 0;
        }
    }
}
