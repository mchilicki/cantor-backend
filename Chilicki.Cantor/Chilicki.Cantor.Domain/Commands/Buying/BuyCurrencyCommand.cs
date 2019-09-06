using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Commands.Buying
{
    public class BuyCurrencyCommand
    {
        public Currency Currency { get; set; }        
        public User User { get; set; }
        public CantorCurrency CantorCurrency { get; set; }
        public WalletCurrency UserBoughtCurrency { get; set; }
        public int Amount { get; set; }
        public decimal UserMoneyCosts { get; set; }
    }
}
