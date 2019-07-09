using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Services.Users.Base
{
    public interface IUserService
    {
        UserToken GenerateUserToken(User user, string secretKey);
        User UpdateUserToken(User user, UserToken userToken);
    }
}
