using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.ValueObjects.Users;
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
