using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Users
{
    public class LoginAlreadyExistsException : BadRequestException
    {
        public LoginAlreadyExistsException() : base("Login already exists")
        {
        }
    }
}
