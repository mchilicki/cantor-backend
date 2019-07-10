using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Wallets.Base
{
    public interface IWalletCurrencyRepository : IBaseRepository<WalletCurrency>
    {
    }
}
