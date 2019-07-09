using Chilicki.Cantor.Domain.ValueObjects.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Application.Commands.Auth
{
    public class AuthenticateUserCommand : IRequest<UserToken>
    {
        public string LoginOrEmail { get; set; }
        public string Password { get; set; }
    }
}
