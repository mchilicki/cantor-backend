﻿using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> FindByLoginOrEmailAndPassword(UserCredentials userCredentials)
        {
            return await entities
                .FirstOrDefaultAsync(p => (p.Login == userCredentials.LoginOrEmail ||
                    p.Email == userCredentials.LoginOrEmail) && p.Password == userCredentials.Password);
        }

        public async Task<bool> DoesEmailAlreadyExists(string email)
        {
            return await entities
                .AnyAsync(p => p.Email == email);
        }

        public async Task<bool> DoesLoginAlreadyExists(string login)
        {
            return await entities
                .AnyAsync(p => p.Login == login);
        }
    }
}
