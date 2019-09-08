using Chilicki.Cantor.Domain.Entities;

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
