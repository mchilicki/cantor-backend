using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Wallets
{
    public class WalletCurrencyRepository : BaseRepository<WalletCurrency>, IWalletCurrencyRepository
    {
        public WalletCurrencyRepository(DbContext context) : base(context)
        {
        }
    }
}
