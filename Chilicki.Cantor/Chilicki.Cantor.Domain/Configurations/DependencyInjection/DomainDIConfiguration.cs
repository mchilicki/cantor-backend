using Chilicki.Cantor.Domain.Factories.Currencies;
using Chilicki.Cantor.Domain.Factories.Currencies.Base;
using Chilicki.Cantor.Domain.Factories.Initializing;
using Chilicki.Cantor.Domain.Factories.Initializing.Base;
using Chilicki.Cantor.Domain.Factories.Users;
using Chilicki.Cantor.Domain.Factories.Users.Base;
using Chilicki.Cantor.Domain.Services.Auth;
using Chilicki.Cantor.Domain.Services.Auth.Base;
using Chilicki.Cantor.Domain.Services.Buying;
using Chilicki.Cantor.Domain.Services.Buying.Base;
using Chilicki.Cantor.Domain.Services.Calculations;
using Chilicki.Cantor.Domain.Services.Calculations.Base;
using Chilicki.Cantor.Domain.Services.Charges;
using Chilicki.Cantor.Domain.Services.Charges.Base;
using Chilicki.Cantor.Domain.Services.Currencies;
using Chilicki.Cantor.Domain.Services.Currencies.Base;
using Chilicki.Cantor.Domain.Services.Users;
using Chilicki.Cantor.Domain.Services.Users.Base;
using Chilicki.Cantor.Domain.Validators.Buying;
using Chilicki.Cantor.Domain.Validators.Buying.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor
{
    public static class DomainDIConfiguration
    {
        public static void RegisterDomainDependencies(this IServiceCollection services)
        {
            services.RegisterServices();
            services.RegisterFactories();
            services.RegisterValidators();
        }

        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IChargeAccountService, ChargeAccountService>();
            services.AddScoped<IBuyCurrencyService, BuyCurrencyService>();
            services.AddScoped<ICantorCostsCalculator, CantorCostsCalculator>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserTokenGenerator, UserTokenGenerator>();
            services.AddScoped<ICurrencyUpdateService, CurrencyUpdateService>();
        }

        private static void RegisterFactories(this IServiceCollection services)
        {
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IUserTokenFactory, UserTokenFactory>();
            services.AddScoped<IWalletCurrencyFactory, WalletCurrencyFactory>();
            services.AddScoped<IInitializeCurrenciesFactory, InitializeCurrenciesFactory>();
        }

        private static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IBuyCurrencyValidator, BuyCurrencyValidator>();
        }
    }
}
