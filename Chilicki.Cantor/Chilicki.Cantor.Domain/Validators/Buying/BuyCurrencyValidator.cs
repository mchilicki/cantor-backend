using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Helpers.Exceptions.Buying;
using Chilicki.Cantor.Domain.Validators.Buying.Base;

namespace Chilicki.Cantor.Domain.Validators.Buying
{
    public class BuyCurrencyValidator : IBuyCurrencyValidator
    {
        public bool ValidateCanBuyCurrency(BuyCurrencyCommand command)
        {
            if (HasUserNotEnoughFunds(command))
                throw new BuyCurrencyException("User doesn't have enough funds");
            if (HasCantorNotEnoughCurrencyAmount(command))
                throw new BuyCurrencyException("Cantor doesn't have enough currency amount");
            if (AmountIsNotMultipleOfUnit(command))
                throw new BuyCurrencyException("Amount is not multiple of currency sell unit");
            return true;
        }

        private bool AmountIsNotMultipleOfUnit(BuyCurrencyCommand command)
        {
            return command.Amount % command.Currency.Unit != 0;
        }

        private bool HasCantorNotEnoughCurrencyAmount(BuyCurrencyCommand command)
        {
            return command.CantorCurrency.Amount < command.Amount;
        }

        private bool HasUserNotEnoughFunds(BuyCurrencyCommand command)
        {
            return command.User.Money < command.UserMoneyCosts;
        }
    }
}
