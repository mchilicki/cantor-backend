using Chilicki.Cantor.Domain.Commands.Base;

namespace Chilicki.Cantor.Domain.Validators.Transactions.Base
{
    public interface ITransactionValidator
    {
        bool ValidateTransaction(TransactionCommand command);
    }
}