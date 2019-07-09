using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Application.Commands.Auth
{
    public class UserAuthenticateCommand : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
