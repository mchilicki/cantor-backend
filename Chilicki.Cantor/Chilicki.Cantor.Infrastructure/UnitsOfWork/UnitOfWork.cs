using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
