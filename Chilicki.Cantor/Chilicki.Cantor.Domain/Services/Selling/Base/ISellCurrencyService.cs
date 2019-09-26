using System.Threading.Tasks;
using Chilicki.Cantor.Domain.Commands.Selling;
using Chilicki.Cantor.Domain.Entities;

namespace Chilicki.Cantor.Domain.Services.Selling.Base
{
    public interface ISellCurrencyService
    {
        User SellCurrency(SellCurrencyCommand command);
    }
}