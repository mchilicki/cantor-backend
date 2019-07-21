using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Base
{
    public class UnathorizedException : Exception
    {
        public UnathorizedException(string message) : base(message)
        {
        }
    }
}
