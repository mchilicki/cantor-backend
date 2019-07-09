using Chilicki.Cantor.Domain.Aggregates.Users;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Factories.Users.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Factories.Users
{
    public class UserFactory : IUserFactory
    {
        public User Create(UserToRegister userToRegister)
        {
            return new User()
            {
                Email = userToRegister.Email,
                FirstName = userToRegister.Email,
                LastName = userToRegister.LastName,
                Login = userToRegister.Login,
                Password = userToRegister.Password,
            };
        }
    }
}
