using Chilicki.Cantor.Application.Commands.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.Auth
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        public Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
