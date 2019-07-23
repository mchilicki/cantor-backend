using AutoMapper;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.WebAPI.Configurations.Automapper
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
        }
    }
}
