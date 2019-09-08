using Chilicki.Cantor.Domain.Commands.Buying;

namespace Chilicki.Cantor.Domain.Validators.Buying.Base
{
    public interface IBuyCurrencyValidator
    {
        bool ValidateCanBuyCurrency(BuyCurrencyCommand command);
    }
}