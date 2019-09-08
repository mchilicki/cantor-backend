using Chilicki.Cantor.Application.CommandHandlers.Auth;
using Chilicki.Cantor.Application.CommandHandlers.Buying;
using Chilicki.Cantor.Application.CommandHandlers.Charges;
using Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters;
using Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters.Base;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.Commands.Charges;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Application.Helpers.Users;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Mappers;
using Chilicki.Cantor.Application.Mappers.Base;
using Chilicki.Cantor.Application.Queries;
using Chilicki.Cantor.Application.QueryHandlers;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor
{
    public static class ApplicationDIConfiguration
    {
        public static IServiceCollection RegisterAllDependencies(this IServiceCollection services)
        {
            services.RegisterInfrastructureDependencies();
            services.RegisterDomainDependencies();
            services.RegisterApplicationDependencies();
            return services;
        }

        private static void RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.RegisterRequestHandlers();
            services.RegisterMappers();
            services.RegisterServices();
        }

        private static void RegisterRequestHandlers(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AuthenticateUserCommand, UserToken>, AuthenticateUserHandler>();
            services.AddScoped<IRequestHandler<RegisterUserCommand, UserDto>, RegisterUserHandler>();
            services.AddScoped<IRequestHandler<ChargeAccountCommand, UserDto>, ChargeAccountHandler>();
            services.AddScoped<IRequestHandler<GetCantorCurrenciesQuery, IEnumerable<CantorCurrencyDto>>, GetCantorCurrenciesHandler>();
            services.AddScoped<IRequestHandler<GetUserCurrenciesQuery, IEnumerable<UserCurrencyDto>>, GetUserCurrenciesHandler>();
            services.AddScoped<IRequestHandler<BuyCurrencyCommandDto, UserDto>, BuyCurrencyHandler>();
        }

        private static void RegisterMappers(this IServiceCollection services)
        {
            services.AddScoped<IBuyCurrencyCommandMapper, BuyCurrencyCommandMapper>();
            services.AddScoped<CurrencyMapper>();
            services.AddScoped<CurrencyValueMapper>();
        }

        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICurrencyUpdater, CurrencyUpdater>();
        }
    }
}
