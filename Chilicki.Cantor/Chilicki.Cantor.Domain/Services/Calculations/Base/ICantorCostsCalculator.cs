using Chilicki.Cantor.Domain.Entities;

namespace Chilicki.Cantor.Domain.Services.Calculations.Base
{
    public interface ICantorCostsCalculator
    {
        decimal CountUserCostsInPln(Currency currency, int amount);
    }
}
