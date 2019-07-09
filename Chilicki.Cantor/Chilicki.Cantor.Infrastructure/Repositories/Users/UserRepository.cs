using Chilicki.Cantor.Domain.Aggregates.Users;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> FindByLogin(string login)
        {
            return await _entities
                .FirstOrDefaultAsync(p => p.Login == login);
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _entities
                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<bool> DoesEmailAlreadyExists(string email)
        {
            return await _entities
                .AnyAsync(p => p.Email == email);
        }

        public async Task<bool> DoesLoginAlreadyExists(string login)
        {
            return await _entities
                .AnyAsync(p => p.Login == login);
        }
    }
}
