﻿using Chilicki.Cantor.Domain.Commands.Selling;

namespace Chilicki.Cantor.Domain.Validators.Selling.Base
{
    public interface ISellCurrencyValidator
    {
        bool ValidateCanSellCurrency(SellCurrencyCommand command);
    }
}