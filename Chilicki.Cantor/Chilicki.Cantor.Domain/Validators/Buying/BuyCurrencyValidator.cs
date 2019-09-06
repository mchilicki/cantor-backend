using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Helpers.Exceptions.Buying;
using Chilicki.Cantor.Domain.Validators.Buying.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chilicki.Cantor.Domain.Validators.Buying
{
    public class BuyCurrencyValidator : IBuyCurrencyValidator
    {
        public bool ValidateCanBuyCurrency(BuyCurrencyCommand command)
        {
            if (!HasUserFunds(command))
                throw new BuyCurrencyException("User doesn't have enough funds");
            if (!HasCantorCurrencyAmount(command))
                throw new BuyCurrencyException("Cantor doesn't have enough currency amount");
            return true;
        }

        private bool HasCantorCurrencyAmount(BuyCurrencyCommand command)
        {
            return command.CantorCurrency.Amount >= command.Amount;
        }

        private bool HasUserFunds(BuyCurrencyCommand command)
        {
            return command.User.Money >= command.UserMoneyCosts;
        }
    }
}
