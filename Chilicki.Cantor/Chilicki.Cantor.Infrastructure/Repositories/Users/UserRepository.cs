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

        public async Task<bool> DoesUserAlreadyExists(UserToRegister userToRegister)
        {
            return await _entities
                .AllAsync(p => p.Email != userToRegister.Email &&
                     p.Login != userToRegister.Login);
        }
    }
}
