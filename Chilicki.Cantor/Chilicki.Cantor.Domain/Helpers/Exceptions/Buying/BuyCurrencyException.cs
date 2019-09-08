using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Buying
{
    public class BuyCurrencyException : BadRequestException
    {
        public BuyCurrencyException(string message) : base(message)
        {
        }
    }
}
