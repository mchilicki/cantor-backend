using Chilicki.Cantor.Domain.Commands.Base;
using Chilicki.Cantor.Domain.Helpers.Exceptions.Transactions;
using Chilicki.Cantor.Domain.Validators.Transactions.Base;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Validators.Transactions
{
    public class TransactionValidator : ITransactionValidator
    {
        public bool ValidateTransaction(TransactionCommand command)
        {
            if (AmountIsNotMultipleOfUnit(command))
                throw new TransactionException("Amount is not multiple of currency sell unit");
            if (IsCurrenciesPublicationDateTooOld(command))
                throw new TransactionException("Currencies are out of date");
            return true;
        }

        private bool IsCurrenciesPublicationDateTooOld(TransactionCommand command)
        {
            double totalDaysOutOfDate = (DateTime.Now - command.CantorWallet.PublicationDate).TotalDays;
            return totalDaysOutOfDate > 2;
        }

        private bool AmountIsNotMultipleOfUnit(TransactionCommand command)
        {
            return command.Amount % command.Currency.Unit != 0;
        }
    }
}
