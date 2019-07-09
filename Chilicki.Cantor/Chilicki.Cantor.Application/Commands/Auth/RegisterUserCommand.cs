using Chilicki.Cantor.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Application.Commands.Auth
{
    public class RegisterUserCommand : IRequest<UserDTO>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
