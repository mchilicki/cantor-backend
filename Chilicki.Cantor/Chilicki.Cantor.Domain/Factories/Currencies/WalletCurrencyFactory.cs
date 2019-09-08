using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Factories.Currencies.Base;

namespace Chilicki.Cantor.Domain.Factories.Currencies
{
    public class WalletCurrencyFactory : IWalletCurrencyFactory
    {
        public WalletCurrency Create(Currency currency, User owner, int amount)
        {
            return new WalletCurrency()
            {
                Owner = owner,
                Currency = currency, 
                Amount = amount,
            };
        }
    }
}
