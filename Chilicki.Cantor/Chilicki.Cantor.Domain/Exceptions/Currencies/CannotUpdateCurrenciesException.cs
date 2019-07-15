using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Exceptions.Currencies
{
    public class CannotUpdateCurrenciesException : Exception
    {
        public CannotUpdateCurrenciesException()
        {
        }

        public CannotUpdateCurrenciesException(string message) : base(message)
        {
        }
    }
}
