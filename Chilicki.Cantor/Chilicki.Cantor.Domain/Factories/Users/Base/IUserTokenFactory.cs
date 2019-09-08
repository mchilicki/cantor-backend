using Chilicki.Cantor.Domain.ValueObjects.Users;

namespace Chilicki.Cantor.Domain.Factories.Users.Base
{
    public interface IUserTokenFactory
    {
        UserToken Create(string token);
    }
}
