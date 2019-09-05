using Chilicki.Cantor.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext context;
        protected DbSet<TEntity> entities; 

        public BaseRepository(DbContext context)
        {
            this.context = context;
            entities = this.context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<TEntity> FindAsync(string key)
        {
            var keyGuid = Guid.Parse(key);
            return await entities.FindAsync(keyGuid);
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await entities.FindAsync(keyValues);
        }

        public TEntity Find(params object[] keyValues)
        {
            return entities.Find(keyValues);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await entities.AddAsync(entity);
            return entry.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.entities.AddRangeAsync(entities);
        }

        public async Task<int> GetCountAsync()
        {
            return await entities.CountAsync();
        }
    }
}
