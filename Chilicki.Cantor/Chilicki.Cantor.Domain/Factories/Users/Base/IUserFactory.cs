using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.ValueObjects.Users;

namespace Chilicki.Cantor.Domain.Factories.Users.Base
{
    public interface IUserFactory
    {
        User Create(UserToRegister userToRegister);
    }
}
