using AutoMapper;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Application.Mappers
{
    public class CurrencyValueMapper : IValueResolver<WalletCurrency, UserCurrencyDto, decimal>
    {
        public decimal Resolve(WalletCurrency source, UserCurrencyDto destination, decimal destMember, ResolutionContext context)
        {
            return source.Value * source.Currency.SellPrice;
        }
    }
}
