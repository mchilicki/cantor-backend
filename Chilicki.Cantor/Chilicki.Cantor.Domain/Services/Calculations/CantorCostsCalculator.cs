﻿using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Services.Calculations.Base;

namespace Chilicki.Cantor.Domain.Services.Calculations
{
    public class CantorCostsCalculator : ICantorCostsCalculator
    {
        public decimal CountUserCostsInPln(Currency currency, int amount)
        {
            var userCostsInPln = amount * currency.SellPrice / currency.Unit;
            return userCostsInPln;
        }

        public decimal CountUserEarnsInPln(Currency currency, int amount)
        {
            var userCostsInPln = amount * currency.PurchasePrice / currency.Unit;
            return userCostsInPln;
        }
    }
}
