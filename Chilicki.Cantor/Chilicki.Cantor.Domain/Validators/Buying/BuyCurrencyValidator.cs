using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Helpers.Exceptions.Buying;
using Chilicki.Cantor.Domain.Validators.Buying.Base;
using Chilicki.Cantor.Domain.Validators.Transactions.Base;

namespace Chilicki.Cantor.Domain.Validators.Buying
{
    public class BuyCurrencyValidator : IBuyCurrencyValidator
    {
        readonly ITransactionValidator transactionValidator;

        public BuyCurrencyValidator(
            ITransactionValidator transactionValidator)
        {
            this.transactionValidator = transactionValidator;
        }

        public bool ValidateCanBuyCurrency(BuyCurrencyCommand command)
        {
            transactionValidator.ValidateTransaction(command);
            if (HasUserNotEnoughFunds(command))
                throw new BuyCurrencyException("User doesn't have enough funds");
            if (HasCantorNotEnoughCurrencyAmount(command))
                throw new BuyCurrencyException("Cantor doesn't have enough currency amount");
            return true;
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
