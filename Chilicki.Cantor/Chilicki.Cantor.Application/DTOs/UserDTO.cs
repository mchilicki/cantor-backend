using Chilicki.Cantor.Application.DTOs.Currencies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Money { get; set; }
        public IEnumerable<UserCurrencyDto> Currencies { get; set; }
    }
}
