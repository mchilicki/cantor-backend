using System;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Base
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
