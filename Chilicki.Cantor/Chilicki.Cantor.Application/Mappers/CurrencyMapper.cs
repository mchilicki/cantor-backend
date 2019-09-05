using AutoMapper;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Mappers
{
    public class CurrencyMapper : ITypeConverter<UserCurrencyDto, Currency>
    {
        readonly ICurrencyRepository currencyRepository;

        public CurrencyMapper(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public Currency Convert(UserCurrencyDto source, Currency destination, ResolutionContext context)
        {
            var currency = currencyRepository.Find(source.Id);
            return currency;
        }
    }
}
