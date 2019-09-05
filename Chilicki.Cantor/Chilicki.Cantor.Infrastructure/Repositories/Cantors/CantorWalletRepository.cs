using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Chilicki.Cantor.Infrastructure.Repositories.Cantors
{
    public class CantorWalletRepository : BaseRepository<CantorWallet>, ICantorWalletRepository
    {
        public CantorWalletRepository(DbContext context) : base(context)
        {
        }

        public async Task<CantorWallet> GetCantorWalletAsync()
        {
            // TODO Including in EF Core needs including
            return await entities
                .Include(p => p.CantorCurrencies)
                //.ThenInclude
                .FirstOrDefaultAsync();
        }

        public CantorWallet GetCantorWallet()
        {
            return entities
                .Include(p => p.CantorCurrencies)
                .FirstOrDefault();
        }
    }
}
