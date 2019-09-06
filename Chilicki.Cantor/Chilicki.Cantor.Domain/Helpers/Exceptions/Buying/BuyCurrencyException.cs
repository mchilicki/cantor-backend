using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Buying
{
    public class BuyCurrencyException : Exception
    {
        public BuyCurrencyException(string message) : base(message)
        {
        }
    }
}
