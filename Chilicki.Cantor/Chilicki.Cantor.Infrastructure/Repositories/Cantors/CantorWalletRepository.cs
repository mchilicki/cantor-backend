using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace Chilicki.Cantor.Infrastructure.Repositories.Cantors
{
    public class CantorWalletRepository : BaseRepository<CantorWallet>, ICantorWalletRepository
    {
        public CantorWalletRepository(DbContext context) : base(context)
        {
        }

        public async Task<CantorWallet> GetCantorWalletAsync()
        {
            return await GetCantorWalletQueryable()
                .FirstOrDefaultAsync();
        }        

        public CantorWallet GetCantorWallet()
        {
            return GetCantorWalletQueryable()
                .FirstOrDefault();
        }

        private IIncludableQueryable<CantorWallet, Currency> GetCantorWalletQueryable()
        {
            return entities
                .Include(p => p.CantorCurrencies)
                    .ThenInclude(p => p.Currency);
        }
    }
}
