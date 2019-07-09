using Chilicki.Cantor.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Find(params object[] keyValuesd);
        Task<TEntity> AddAsync(TEntity entity);
    }
}
