using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Application.DTOs.Currencies
{
    public class UserCurrencyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Unit { get; set; }
        public decimal SellPrice { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
    }
}
