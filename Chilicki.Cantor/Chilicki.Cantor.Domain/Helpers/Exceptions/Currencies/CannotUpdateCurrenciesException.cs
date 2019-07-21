using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Currencies
{
    public class CannotUpdateCurrenciesException : BadRequestException
    {
        public CannotUpdateCurrenciesException(string message) : base(message)
        {
        }
    }
}
