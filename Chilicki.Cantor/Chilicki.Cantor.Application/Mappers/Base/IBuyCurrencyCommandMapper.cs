using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Domain.Commands.Buying;

namespace Chilicki.Cantor.Application.Mappers.Base
{
    public interface IBuyCurrencyCommandMapper
    {
        BuyCurrencyCommand Map(BuyCurrencyCommandDto source);
    }
}