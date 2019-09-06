using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Services.Calculations.Base
{
    public interface ICantorCostsCalculator
    {
        decimal CountUserCostsInPln(Currency currency, int amount);
    }
}
