using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Domain.Commands.Buying;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Mappers.Base
{
    public interface IBuyCurrencyCommandMapper
    {
        Task<BuyCurrencyCommand> Map(BuyCurrencyCommandDto source);
    }
}