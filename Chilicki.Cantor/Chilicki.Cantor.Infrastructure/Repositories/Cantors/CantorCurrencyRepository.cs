using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Cantors
{
    public class CantorCurrencyRepository : BaseRepository<CantorCurrency>, ICantorCurrencyRepository
    {
        public CantorCurrencyRepository(DbContext context) : base(context)
        {
        }
    }
}
