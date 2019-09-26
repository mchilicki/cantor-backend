using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Application.Commands.Transactions
{
    public class TransactionCommandDto
    {
        public Guid CurrencyId { get; set; }
        public int Amount { get; set; }
    }
}
