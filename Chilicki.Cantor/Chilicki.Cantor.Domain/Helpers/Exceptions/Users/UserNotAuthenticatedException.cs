using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Users
{
    public class UserNotAuthenticatedException : UnathorizedException
    {
        public UserNotAuthenticatedException() : base("You do not have permissions to view that page")
        {
        }
    }
}
