using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Users
{
    public class EmailAlreadyExistsException : BadRequestException
    {
        public EmailAlreadyExistsException() : base("Email already exists")
        {
        }
    }
}
