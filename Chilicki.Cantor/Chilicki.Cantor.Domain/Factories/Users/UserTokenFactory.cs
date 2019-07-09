using Chilicki.Cantor.Domain.Factories.Users.Base;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Factories.Users
{
    public class UserTokenFactory : IUserTokenFactory
    {
        public UserToken Create(string token)
        {
            return new UserToken()
            {
                Token = token,
            };
        }
    }
}
