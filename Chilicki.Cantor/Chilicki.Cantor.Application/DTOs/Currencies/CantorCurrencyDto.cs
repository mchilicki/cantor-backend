using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Application.DTOs.Currencies
{
    public class CantorCurrencyDto : CurrencyDto
    {
        public decimal PurchasePrice { get; set; }
    }
}
