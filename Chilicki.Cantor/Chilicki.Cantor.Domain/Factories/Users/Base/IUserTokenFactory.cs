using Chilicki.Cantor.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Factories.Users.Base
{
    public interface IUserTokenFactory
    {
        UserToken Create(string token);
    }
}
