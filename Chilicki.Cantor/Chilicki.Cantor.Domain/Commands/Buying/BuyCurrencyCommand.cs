using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Commands.Buying
{
    public class BuyCurrencyCommand
    {
        public virtual Currency Currency { get; set; }        
        public virtual User User { get; set; }
        public virtual CantorCurrency CantorCurrency { get; set; }
        public virtual WalletCurrency UserBoughtCurrency { get; set; }
        public int Amount { get; set; }
        public decimal UserMoneyCosts { get; set; }
    }
}
