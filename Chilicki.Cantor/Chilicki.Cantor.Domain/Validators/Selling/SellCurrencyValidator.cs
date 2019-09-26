using Chilicki.Cantor.Domain.Commands.Selling;
using Chilicki.Cantor.Domain.Helpers.Exceptions.Selling;
using Chilicki.Cantor.Domain.Validators.Selling.Base;
using Chilicki.Cantor.Domain.Validators.Transactions.Base;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Validators.Selling
{
    public class SellCurrencyValidator : ISellCurrencyValidator
    {
        readonly ITransactionValidator transactionValidator;

        public SellCurrencyValidator(
            ITransactionValidator transactionValidator)
        {
            this.transactionValidator = transactionValidator;
        }

        public bool ValidateCanSellCurrency(SellCurrencyCommand command)
        {
            transactionValidator.ValidateTransaction(command);
            if (HasUserNotEnoughCurrencyAmount(command))
                throw new SellCurrencyException("User doesn't have enough currency amount");            
            return true;
        }        

        private bool HasUserNotEnoughCurrencyAmount(SellCurrencyCommand command)
        {
            return command.UserCurrency.Amount < command.Amount;
        }
    }
}
