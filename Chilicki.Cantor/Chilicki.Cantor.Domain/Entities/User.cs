﻿using Chilicki.Cantor.Domain.Entities.Base;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public decimal Money { get; set; }
        public virtual ICollection<WalletCurrency> Currencies { get; set; }
    }
}
