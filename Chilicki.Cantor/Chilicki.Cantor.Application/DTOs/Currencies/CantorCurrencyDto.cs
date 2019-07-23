using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Application.DTOs.Currencies
{
    public class CantorCurrencyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Unit { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
