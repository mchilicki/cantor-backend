using Chilicki.Cantor.Domain.Entities.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Users;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets.Base;
using Chilicki.Cantor.Infrastructure.RestClients;
using Chilicki.Cantor.Infrastructure.RestClients.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor
{
    public static class InfrastructureDIConfiguration
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services)
        {
            services.RegisterRepositories();
            services.RegisterBaseRepositories();
            services.RegisterRestClients();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICantorCurrencyRepository, CantorCurrencyRepository>();
            services.AddScoped<ICantorWalletRepository, CantorWalletRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IWalletCurrencyRepository, WalletCurrencyRepository>();
        }

        private static void RegisterBaseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
        }

        private static void RegisterRestClients(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyUpdaterRestClient, CurrencyUpdaterRestClient>();
        }
    }
}
