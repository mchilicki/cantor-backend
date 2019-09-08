using Chilicki.Cantor.Application.DTOs;
using MediatR;

namespace Chilicki.Cantor.Application.Commands.Auth
{
    public class RegisterUserCommand : IRequest<UserDto>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
