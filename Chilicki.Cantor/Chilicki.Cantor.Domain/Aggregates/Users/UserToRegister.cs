using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Aggregates.Users
{
    public class UserToRegister
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
