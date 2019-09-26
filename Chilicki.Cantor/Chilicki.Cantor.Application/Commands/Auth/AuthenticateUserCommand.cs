using Chilicki.Cantor.Application.DTOs;
using MediatR;

namespace Chilicki.Cantor.Application.Commands.Auth
{
    public class AuthenticateUserCommand : IRequest<UserDto>
    {
        public string LoginOrEmail { get; set; }
        public string Password { get; set; }
    }
}
