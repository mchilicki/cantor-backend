using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Services.Auth.Base
{
    public interface IUserTokenGenerator
    {
        string GenerateToken(User user, string secretKey);
    }
}
