using System;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Base
{
    public class UnathorizedException : Exception
    {
        public UnathorizedException(string message) : base(message)
        {
        }
    }
}
