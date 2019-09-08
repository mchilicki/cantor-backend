using Chilicki.Cantor.Domain.Entities;

namespace Chilicki.Cantor.Domain.Services.Auth.Base
{
    public interface IUserTokenGenerator
    {
        string GenerateToken(User user, string secretKey);
    }
}
