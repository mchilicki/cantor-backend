using AutoMapper;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Domain.Aggregates.Users;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.WebAPI.Configurations.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.WebAPI.Configurations
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<RegisterUserCommand, UserToRegister>();
            CreateMap<User, UserDTO>();
        }
    }
}
