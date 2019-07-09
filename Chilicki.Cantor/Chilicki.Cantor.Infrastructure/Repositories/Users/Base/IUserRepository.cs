using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Users.Base
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindByLoginOrEmailAndPassword(UserCredentials userCredentials);
        Task<User> FindByLogin(string login);
        Task<User> FindByEmail(string email);
        Task<bool> DoesEmailAlreadyExists(string email);
        Task<bool> DoesLoginAlreadyExists(string login);
    }
}
