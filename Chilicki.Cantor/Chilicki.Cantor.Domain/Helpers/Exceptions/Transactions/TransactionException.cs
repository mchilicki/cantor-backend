using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Transactions
{
    public class TransactionException : BadRequestException
    {
        public TransactionException(string message) : base(message)
        {
        }
    }
}
