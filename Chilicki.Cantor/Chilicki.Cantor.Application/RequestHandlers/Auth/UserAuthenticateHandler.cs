using Chilicki.Cantor.Application.Commands.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.RequestHandlers.Auth
{
    public class UserAuthenticateHandler : IRequestHandler<UserAuthenticateCommand, string>
    {
        public Task<string> Handle(UserAuthenticateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
