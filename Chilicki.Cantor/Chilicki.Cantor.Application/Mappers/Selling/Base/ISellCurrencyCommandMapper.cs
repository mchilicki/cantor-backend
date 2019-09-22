using Chilicki.Cantor.Application.Commands.Selling;
using Chilicki.Cantor.Domain.Commands.Selling;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Mappers.Selling.Base
{
    public interface ISellCurrencyCommandMapper
    {
        Task<SellCurrencyCommand> Map(SellCurrencyCommandDto source);
    }
}