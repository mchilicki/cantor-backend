using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Services.Buying.Base
{
    public interface IBuyCurrencyService
    {
        User BuyCurrency(BuyCurrencyCommand command);
    }
}
