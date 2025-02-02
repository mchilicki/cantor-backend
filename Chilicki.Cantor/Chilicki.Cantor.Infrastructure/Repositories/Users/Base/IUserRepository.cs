﻿using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Users.Base
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindByLoginOrEmailAndPassword(UserCredentials userCredentials);
        Task<bool> DoesEmailAlreadyExists(string email);
        Task<bool> DoesLoginAlreadyExists(string login);
    }
}
