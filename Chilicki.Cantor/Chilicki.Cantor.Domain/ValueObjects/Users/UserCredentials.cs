using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.ValueObjects.Users
{
    public class UserCredentials
    {
        public string LoginOrEmail { get; set; }
        public string Password { get; set; }
    }
}
