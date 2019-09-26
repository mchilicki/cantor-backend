using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Selling
{
    public class SellCurrencyException : BadRequestException
    {
        public SellCurrencyException(string message) : base(message)
        {
        }
    }
}
