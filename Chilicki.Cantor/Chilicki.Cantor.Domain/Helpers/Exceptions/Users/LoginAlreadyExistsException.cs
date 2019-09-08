using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Users
{
    public class LoginAlreadyExistsException : BadRequestException
    {
        public LoginAlreadyExistsException() : base("Login already exists")
        {
        }
    }
}
