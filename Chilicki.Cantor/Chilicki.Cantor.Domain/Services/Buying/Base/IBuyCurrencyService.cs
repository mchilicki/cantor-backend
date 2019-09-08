using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Entities;

namespace Chilicki.Cantor.Domain.Services.Buying.Base
{
    public interface IBuyCurrencyService
    {
        User BuyCurrency(BuyCurrencyCommand command);
    }
}
