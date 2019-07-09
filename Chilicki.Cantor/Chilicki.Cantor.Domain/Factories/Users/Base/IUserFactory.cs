using Chilicki.Cantor.Domain.Aggregates.Users;
using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Factories.Users.Base
{
    public interface IUserFactory
    {
        User Create(UserToRegister userToRegister);
    }
}
