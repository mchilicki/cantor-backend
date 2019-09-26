using Chilicki.Cantor.Domain.Commands.Base;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Commands.Selling
{
    public class SellCurrencyCommand : TransactionCommand
    {
        public decimal UserMoneyEarns { get; set; }
    }
}
