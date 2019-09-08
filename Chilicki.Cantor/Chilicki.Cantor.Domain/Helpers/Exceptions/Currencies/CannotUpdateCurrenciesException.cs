using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;

namespace Chilicki.Cantor.Domain.Helpers.Exceptions.Currencies
{
    public class CannotUpdateCurrenciesException : BadRequestException
    {
        public CannotUpdateCurrenciesException(string message) : base(message)
        {
        }
    }
}
