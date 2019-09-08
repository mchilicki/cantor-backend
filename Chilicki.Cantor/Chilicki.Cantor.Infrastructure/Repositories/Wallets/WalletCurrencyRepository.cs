using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets.Base;
using Microsoft.EntityFrameworkCore;

namespace Chilicki.Cantor.Infrastructure.Repositories.Wallets
{
    public class WalletCurrencyRepository : BaseRepository<WalletCurrency>, IWalletCurrencyRepository
    {
        public WalletCurrencyRepository(DbContext context) : base(context)
        {
        }
    }
}
