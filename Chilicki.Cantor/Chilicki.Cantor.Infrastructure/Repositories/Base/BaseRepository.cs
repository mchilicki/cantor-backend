using Chilicki.Cantor.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext _context;
        protected DbSet<TEntity> _entities; 

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task<TEntity> Find(params object[] keyValues)
        {
            return await _entities.FindAsync(keyValues);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await _entities.AddAsync(entity);
            return entry.Entity;
        }
    }
}
