using AutoMapper;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Application.Mappers;
using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Configurations.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<RegisterUserCommand, UserToRegister>();
            CreateMap<UserToRegister, User>();
            CreateMap<User, UserDto>();
            CreateMap<AuthenticateUserCommand, UserCredentials>();
            CreateMap<Currency, CantorCurrencyDto>();
            CreateMap<WalletCurrency, UserCurrencyDto>()
                .IncludeMembers(p => p.Currency)
                .ForMember(p => p.Value, p => p.MapFrom<CurrencyValueMapper>());
            CreateMap<Currency, UserCurrencyDto>();
            CreateMap<UserCurrencyDto, Currency>()
                .ConvertUsing<CurrencyMapper>();
        }
    }
}
