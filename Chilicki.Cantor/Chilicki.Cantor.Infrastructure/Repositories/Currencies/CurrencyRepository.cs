using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using Microsoft.EntityFrameworkCore;

namespace Chilicki.Cantor.Infrastructure.Repositories.Currencies
{
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DbContext context) : base(context)
        {
        }
    }
}
