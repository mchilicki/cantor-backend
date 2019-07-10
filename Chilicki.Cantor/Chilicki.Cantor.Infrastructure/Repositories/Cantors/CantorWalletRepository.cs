using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Infrastructure.Repositories.Cantors
{
    public class CantorWalletRepository : BaseRepository<CantorWallet>, ICantorWalletRepository
    {
        public CantorWalletRepository(DbContext context) : base(context)
        {
        }
    }
}
