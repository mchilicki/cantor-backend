using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.ValueObjects.Users;

namespace Chilicki.Cantor.Domain.Services.Users.Base
{
    public interface IUserService
    {
        UserToken GenerateUserToken(User user, string secretKey);
        User UpdateUserToken(User user, UserToken userToken);
    }
}
