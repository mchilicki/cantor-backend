using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Services.Calculations.Base;

namespace Chilicki.Cantor.Domain.Services.Calculations
{
    public class CantorCostsCalculator : ICantorCostsCalculator
    {
        public decimal CountUserCostsInPln(Currency currency, int amount)
        {
            var userCostsInPln = amount * currency.SellPrice;
            return userCostsInPln;
        }
    }
}
