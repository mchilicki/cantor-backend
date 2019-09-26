using Chilicki.Cantor.Application.CommandHandlers.Auth;
using Chilicki.Cantor.Application.CommandHandlers.Buying;
using Chilicki.Cantor.Application.CommandHandlers.Charges;
using Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters;
using Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters.Base;
using Chilicki.Cantor.Application.CommandHandlers.Selling;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.Commands.Charges;
using Chilicki.Cantor.Application.Commands.Selling;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Application.Helpers.Users;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Mappers;
using Chilicki.Cantor.Application.Mappers.Base;
using Chilicki.Cantor.Application.Mappers.Buying;
using Chilicki.Cantor.Application.Mappers.Currencies;
using Chilicki.Cantor.Application.Mappers.Selling;
using Chilicki.Cantor.Application.Mappers.Selling.Base;
using Chilicki.Cantor.Application.Mappers.Transactions;
using Chilicki.Cantor.Application.Mappers.Transactions.Base;
using Chilicki.Cantor.Application.Queries;
using Chilicki.Cantor.Application.QueryHandlers;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Chilicki.Cantor
{
    public static class ApplicationDIConfiguration
    {
        public static IServiceCollection RegisterAllDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterInfrastructureDependencies(configuration);
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
            services.AddScoped<IRequestHandler<GetUserCurrenciesQuery, UserDto>, GetUserCurrenciesHandler>();
            services.AddScoped<IRequestHandler<BuyCurrencyCommandDto, UserDto>, BuyCurrencyHandler>();
            services.AddScoped<IRequestHandler<SellCurrencyCommandDto, UserDto>, SellCurrencyHandler>();
        }

        private static void RegisterMappers(this IServiceCollection services)
        {
            services.AddScoped<IBuyCurrencyCommandMapper, BuyCurrencyCommandMapper>();
            services.AddScoped<ISellCurrencyCommandMapper, SellCurrencyCommandMapper>();
            services.AddScoped<ITransactionCommandMapper, TransactionCommandMapper>();
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
