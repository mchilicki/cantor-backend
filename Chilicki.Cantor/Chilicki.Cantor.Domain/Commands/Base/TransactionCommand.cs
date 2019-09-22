using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Commands.Base
{
    public abstract class TransactionCommand
    {
        public virtual Currency Currency { get; set; }
        public virtual User User { get; set; }
        public virtual CantorCurrency CantorCurrency { get; set; }
        public virtual WalletCurrency UserCurrency { get; set; }
        public int Amount { get; set; }
    }
}
